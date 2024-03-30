using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI NowscoreText;

    void Start()
    {
        if (UIManager.instance != null)
        {
            scoreText.text = "Score:" + UIManager.instance.score + "m";//�ő�L�^�\��
            NowscoreText.text = "Score:" + UIManager.instance.nowscore + "m";//���݂̈ʒu�\��
        }
        else
        {
            Debug.Log("�Q�[���}�l�[�W���[�u���Y��Ă��I");
            Destroy(this);
        }
    }
    private void Update()
    {
        scoreText.text = "Score:" + UIManager.instance.score + "m";//��ʂɔ��f
        NowscoreText.text = "Score:" + UIManager.instance.nowscore + "m";//��ʂɔ��f
    }
}
