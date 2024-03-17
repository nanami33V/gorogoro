using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distanceScript : MonoBehaviour
{
    private float score = 0;
    public int log;
    bool startGame = false;
    Vector2 startPosition;
    Vector2 nowPosition;
   
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance != null&&startGame==true)
        {
            nowPosition = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
            float scorenum = Mathf.Round((nowPosition.x - startPosition.x) * log);
            if (score < scorenum) score = scorenum;
            GameManager.instance.score = score;
            GameManager.instance.nowscore = scorenum;
        }
       
    }
    private IEnumerator startPos()
    {
        startPosition = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        startGame = true;
        yield break;
    }
    public void Callstart()
    {
        StartCoroutine("startPos");
    }
}
