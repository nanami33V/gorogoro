using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distanceScript : MonoBehaviour
{
    public float scoreNow=0;
    public int log;
    bool startGame = false;
    Vector2 startPosition;
    Vector2 nowPosition;

    // Update is called once per frame
    private void Start()
    {
        GameManager.instance.Endscore= PlayerPrefs.GetFloat("EndScore", 0);//�O��̃X�R�A���Z�[�u�f�[�^����擾
        GameManager.instance.Highscore = PlayerPrefs.GetFloat("HighScore", 0);//�ō��X�R�A���Z�[�u�f�[�^����擾
    }
    void Update()
    {
        if (GameManager.instance != null&&startGame==true)//�ʒu���擾
        {
            nowPosition = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
            scoreNow = Mathf.Round((nowPosition.x - startPosition.x) * log);
        }
        GameManager.instance.nowscore = scoreNow;

    }
    public void SaveSt()//�Z�[�u����
    {
        if(GameManager.instance.Highscore<scoreNow) PlayerPrefs.SetFloat("HighScore", scoreNow);
        PlayerPrefs.SetFloat("EndScore", scoreNow);
        PlayerPrefs.Save();
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
