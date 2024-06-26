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
            scoreText.text = "HighScore:" + GameManager.instance.Highscore+"m";//最大記録表示
            NowscoreText.text = "Score:" + GameManager.instance.nowscore + "m";//現在の位置表示
        }
        else
        {
            Debug.Log("ゲームマネージャー置き忘れてるよ！");
            Destroy(this);
        }
    }
    private void Update()
    {
        NowscoreText.text = "Score:" + GameManager.instance.nowscore + "m";//画面に反映
        ResultScoreText.text = GameManager.instance.nowscore + "m";
    }
}
