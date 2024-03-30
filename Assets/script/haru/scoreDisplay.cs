using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreDisplay: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI NowscoreText;

    [SerializeField] TextMeshProUGUI ResultScoreText;

    void Start()
    {
        if (GameManager.instance != null)
        {
            scoreText.text = "HighScore:" + GameManager.instance.Highscore+"m";//�ő�L�^�\��
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
        NowscoreText.text = "Score:" + GameManager.instance.nowscore + "m";//��ʂɔ��f
        ResultScoreText.text = GameManager.instance.nowscore + "m";
    }
}
