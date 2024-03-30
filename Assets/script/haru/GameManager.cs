using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    //メイン操作キャラ
    public BallControl ballcon;
    //アニメーション取得
    public Animator animMain1;
    public Animator animMain2;
    public Animator animMain3;
    public Animator animMainG;
    public Animator animMainO;
    public Animator animResult;

    //score管理
    public float Endscore;
    public float Highscore;
    public float nowscore = 0;
    public distanceScript distance;

    //sound管理
    public AudioSource SEAudioSource;

    [SerializeField] 
     AudioClip[] clipAudio;

    public GameObject GameOverObj;
    public GameObject Startobj;
    private void Awake()
    {
        Debug.Log("start");
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        StartActiveTrue();
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        animMain1.GetComponent<Animator>();
        animMain2.GetComponent<Animator>();
        animMain3.GetComponent<Animator>();
        animMainG.GetComponent<Animator>();
        animMainO.GetComponent<Animator>();
        animResult.GetComponent<Animator>();
        GameOverObj.SetActive(false);
        
    }

    //start時のアニメーション処理と動作可能処理+SE処理


    public void animNum1()
    {
        animMain1.SetTrigger("1triger");
        SEAudioSource.PlayOneShot(clipAudio[0]);
    }
    public void animNum2()
    {
        animMain2.SetTrigger("2triger");
        SEAudioSource.PlayOneShot(clipAudio[0]);
    }
    public void animNum3()
    {
        animMain3.SetTrigger("3triger");
    }
    public void animNumPlay()
    {
        ballcon.CallPlayDo();
    }
    public void animNumGO()
    {    
        animMainG.SetTrigger("Gtriger");
        animMainO.SetTrigger("Otriger");
        SEAudioSource.PlayOneShot(clipAudio[0]);
    }
    public void CallSeGo()
    {
        SEAudioSource.PlayOneShot(clipAudio[1]);
    }


    //GameOver時に起動
    public void GameOver()
    {
        GameOverObj.SetActive(true);
        animResult.SetTrigger("result");
        distance.SaveSt();

    }
    //GameOver終了の時使用
    public void GameOverStop()
    {
        GameOverObj.SetActive(false);
    }

    public void StartActiveTrue()
    {
        Startobj.gameObject.SetActive(true);
    }
    public void StartActiveFalse()
    {
        Startobj.gameObject.SetActive(false);
    }
}
