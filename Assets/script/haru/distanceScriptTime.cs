using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distanceScriptTime : MonoBehaviour
{
    public float scoreNow=0;
    float TimeSoco;
    float Alltime;
    public int log;
    bool startGame = false;
    Vector2 startPosition;
    Vector2 nowPosition;

    // Update is called once per frame
    private void Start()
    {
        GameManager.instance.TimeScore= PlayerPrefs.GetFloat("nowTimeScore", 0);//現在のセーブデータを取得
        GameManager.instance.BestTimeScore = PlayerPrefs.GetFloat("bestTimeScore", 0);//ベストスコアのセーブデータを取得
        TimeSoco = 0.0f;
    }
    void Update()
    {
        if (GameManager.instance != null&&startGame==true)//時間と位置を取得
        {
            nowPosition = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
            scoreNow = Mathf.Round((nowPosition.x - startPosition.x) * log);
            TimeSoco += Time.deltaTime;
        }
        GameManager.instance.nowscore = scoreNow;
        GameManager.instance.TimeScore = TimeSoco;
    }
    public void SaveSt()//セーブする
    {
        if(GameManager.instance.BestTimeScore>TimeSoco||GameManager.instance.BestTimeScore==0) PlayerPrefs.SetFloat("bestTimeScore", TimeSoco);
        PlayerPrefs.SetFloat("nowTimeScore",TimeSoco );
        PlayerPrefs.Save();
    }
    private IEnumerator startPos()//始めた場所を取得
    {
        if (startGame==false) startPosition = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        startGame = true;
        yield break;
    }
    public void Callstart()//別スクリプトからstartPosを呼び出す
    {
        StartCoroutine("startPos");
    }
}
