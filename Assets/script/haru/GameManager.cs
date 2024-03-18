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
    public GameObject ball;
    //アニメーション取得
    public Animator animMain1;
    public Animator animMain2;
    public Animator animMain3;
    public Animator animMainG;
    public Animator animMainO;

    //score管理
    public float score = 0;
    public float nowscore = 0;
    //sound管理
    public AudioSource myAudioSource;

    [SerializeField] 
     AudioClip[] clipAudio;

    public GameObject GameOverObj;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        animMain1.GetComponent<Animator>();
        animMain2.GetComponent<Animator>();
        animMain3.GetComponent<Animator>();
        animMainG.GetComponent<Animator>();
        animMainO.GetComponent<Animator>();
        GameOverObj.SetActive(false);
        myAudioSource = GetComponent<AudioSource>();
    }

    //start時のアニメーション処理と動作可能処理

   
    public void animNum1()
    {
        animMain2.SetTrigger("2triger");
        myAudioSource.PlayOneShot(clipAudio[0]);
    }
    public void animNum2()
    {
        animMain1.SetTrigger("1triger");
        myAudioSource.PlayOneShot(clipAudio[0]);
    }
    public void animNum3()
    {    
        animMainG.SetTrigger("Gtriger");
        animMainO.SetTrigger("Otriger");
        myAudioSource.PlayOneShot(clipAudio[0]);
    }
    public void animNum4()
    {
        ballcon.CallPlayDo();
        myAudioSource.PlayOneShot(clipAudio[1]);
    }
    public void animNum5()
    {
        animMain3.SetTrigger("3triger");
    }
   

    //GameOver時に起動
    public void GameOver()
    {
        GameOverObj.SetActive(true);
    }

   

    // Start is called before the first frame update
    /*public IEnumerator GameStart()
    {
        yield return new WaitForSeconds(waitTime);
        centerText.enabled = true;
        centerText.text = "3";
        yield return new WaitForSeconds(1);
        centerText.text = "2";
        yield return new WaitForSeconds(1);
        centerText.text = "1";
        yield return new WaitForSeconds(1);
        centerText.text = "GO!!";
        firstPerson.playerCanMove = true;
        firstPerson.enableCameraMovement = true;
        gunCOntroller.shootEnabled = true;
        yield return new WaitForSeconds(1);
        centerText.text = "";
        centerText.enabled = false;
    }*/
}
