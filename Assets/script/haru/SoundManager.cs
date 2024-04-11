using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    

    public float BGMvol=10;
    public float SEvol=10;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        BGMvol = PlayerPrefs.GetFloat("BGMVOL", 10);//•Û‘¶‚µ‚½BGM‚Ì‘å‚«‚³‚ðŽæ“¾
        SEvol = PlayerPrefs.GetFloat("SEVOL", 10);//•Û‘¶‚µ‚½SE‚Ì‘å‚«‚³‚ðŽæ“¾
    }
}
