using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    //���C������L����
    public BallControl ballcon;
    public GameObject ball;
    //�A�j���[�V�����擾
    public Animator animMain1;
    public Animator animMain2;
    public Animator animMain3;
    public Animator animMainG;
    public Animator animMainO;
    public Animator animResult;

    //score�Ǘ�
    public float Endscore;
    public float Highscore;
    public float nowscore = 0;
    public distanceScript distance;

    //sound�Ǘ�
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
        Time.timeScale = 1;
        animMain1.GetComponent<Animator>();
        animMain2.GetComponent<Animator>();
        animMain3.GetComponent<Animator>();
        animMainG.GetComponent<Animator>();
        animMainO.GetComponent<Animator>();
        animResult.GetComponent<Animator>();
        GameOverObj.SetActive(false);
    }

    //start���̃A�j���[�V���������Ɠ���\����+SE����

   
    public void animNum1()
    {
        animMain2.SetTrigger("2triger");
        SEAudioSource.PlayOneShot(clipAudio[0]);
    }
    public void animNum2()
    {
        animMain1.SetTrigger("1triger");
        SEAudioSource.PlayOneShot(clipAudio[0]);
    }
    public void animNum3()
    {    
        animMainG.SetTrigger("Gtriger");
        animMainO.SetTrigger("Otriger");
        SEAudioSource.PlayOneShot(clipAudio[0]);
    }
    public void animNum4()
    {
        ballcon.CallPlayDo();
    }
    public void animNum5()
    {
        animMain3.SetTrigger("3triger");
    }
    public void animNum6()
    {
        SEAudioSource.PlayOneShot(clipAudio[1]);
    }


    //GameOver���ɋN��
    public void GameOver()
    {
        GameOverObj.SetActive(true);
        animResult.SetTrigger("result");
        distance.SaveSt();

    }
    //GameOver�I���̎��g�p
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
