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
            scoreText.text = "Score:" + GameManager.instance.score+"m";//最大記録表示
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
        scoreText.text = "Score:" + GameManager.instance.score + "m";//画面に反映
        NowscoreText.text = "Score:" + GameManager.instance.nowscore + "m";//画面に反映
    }
}
