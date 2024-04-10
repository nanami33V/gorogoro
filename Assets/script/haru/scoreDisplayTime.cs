using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreDisplayTime: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI NowscoreText;
    [SerializeField] TextMeshProUGUI TimeScoreText;

    [SerializeField] TextMeshProUGUI GoalTimeText;


    void Start()
    {
        if (GameManager.instance != null)
        {
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
        //秒数を表示
        float s = GameManager.instance.TimeScore % 60;
        float m = Mathf.FloorToInt(GameManager.instance.TimeScore / 60);
        
        var stime = s.ToString("00.00");
        var mtime = m.ToString("00");

        NowscoreText.text = "Score:" + GameManager.instance.nowscore+"/1000m";//画面に反映
        TimeScoreText.text =  mtime+":"+stime+"s";
        GoalTimeText.text = mtime + ":" + stime + "s";
    }
}
