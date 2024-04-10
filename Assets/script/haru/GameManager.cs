using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
   //���삵�Ă��������䂷��
    public bool DoPlay = false;
    public bool DoPlayTime = false;
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
    public float TimeScore;
    public float BestTimeScore;

    //sound�Ǘ�
    public AudioSource SEAudioSource;
    [SerializeField] 
     AudioClip[] clipAudio;
    //�I�u�W�F�N�g�A�^�b�`
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
        Application.targetFrameRate = 30;//�t���[�����[�g�Œ�
        animMain1.GetComponent<Animator>();
        animMain2.GetComponent<Animator>();
        animMain3.GetComponent<Animator>();
        animMainG.GetComponent<Animator>();
        animMainO.GetComponent<Animator>();
        animResult.GetComponent<Animator>();
    }

    //start���̃A�j���[�V���������Ɠ���\����+SE����
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
    


    //GameOver���ɋN��
    public void GameOver()
    {
        GameOverObj.SetActive(true);
        animResult.SetTrigger("result");
        SEAudioSource.PlayOneShot(clipAudio[3]);
    }
    //GameOver�I���̎��g�p
    public void GameOverStop()
    {
        GameOverObj.SetActive(false);
    }

    //�J�E���g�_�E����image��\��
    public void StartActiveTrue()
    {
        Startobj.gameObject.SetActive(true);
    }
    //�J�E���g�_�E����image���\��
    public void StartActiveFalse()
    {
        Startobj.gameObject.SetActive(false);
    }
    public void Goal()//�S�[�����̏���
    {
        SEAudioSource.PlayOneShot(clipAudio[2]);
        GameOverObj.SetActive(true);
        animResult.SetTrigger("result");
    }
}
