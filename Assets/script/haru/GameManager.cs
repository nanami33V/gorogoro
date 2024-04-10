using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
   //操作していいか制御する
    public bool DoPlay = false;
    public bool DoPlayTime = false;
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
    public float TimeScore;
    public float BestTimeScore;

    //sound管理
    public AudioSource SEAudioSource;
    [SerializeField] 
     AudioClip[] clipAudio;
    //オブジェクトアタッチ
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
        GameOverObj.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;//フレームレート固定
        animMain1.GetComponent<Animator>();
        animMain2.GetComponent<Animator>();
        animMain3.GetComponent<Animator>();
        animMainG.GetComponent<Animator>();
        animMainO.GetComponent<Animator>();
        animResult.GetComponent<Animator>();
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
    public void animNumGO()
    {    
        animMainG.SetTrigger("Gtriger");
        animMainO.SetTrigger("Otriger");
        SEAudioSource.PlayOneShot(clipAudio[0]);
    }
    public void CallSeGo()
    {
        SEAudioSource.PlayOneShot(clipAudio[1]);
        DoPlay = true;
    }
    


    //GameOver時に起動
    public void GameOver()
    {
        GameOverObj.SetActive(true);
        animResult.SetTrigger("result");
        SEAudioSource.PlayOneShot(clipAudio[3]);
    }
    //GameOver終了の時使用
    public void GameOverStop()
    {
        GameOverObj.SetActive(false);
    }

    //カウントダウンのimageを表示
    public void StartActiveTrue()
    {
        Startobj.gameObject.SetActive(true);
    }
    //カウントダウンのimageを非表示
    public void StartActiveFalse()
    {
        Startobj.gameObject.SetActive(false);
    }
    public void Goal()//ゴール時の処理
    {
        SEAudioSource.PlayOneShot(clipAudio[2]);
        GameOverObj.SetActive(true);
        animResult.SetTrigger("result");
    }
}
