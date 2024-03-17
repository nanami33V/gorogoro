using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreDistance : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI NowscoreText;
   
    void Start()
    {
        if (GameManager.instance != null)
        {
            scoreText.text = "Score:" + GameManager.instance.score+"m";//�ő�L�^�\��
            NowscoreText.text = "Score:" + GameManager.instance.nowscore + "m";//���݂̈ʒu�\��
        }
        else
        {
            Debug.Log("�Q�[���}�l�[�W���[�u���Y��Ă��I");
            Destroy(this);
        }
    }
    private void Update()
    {
        scoreText.text = "Score:" + GameManager.instance.score + "m";//��ʂɔ��f
        NowscoreText.text = "Score:" + GameManager.instance.nowscore + "m";//��ʂɔ��f
    }
}
