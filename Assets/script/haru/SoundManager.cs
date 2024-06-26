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
        BGMvol = PlayerPrefs.GetFloat("BGMVOL", 10);//保存したBGMの大きさを取得
        SEvol = PlayerPrefs.GetFloat("SEVOL", 10);//保存したSEの大きさを取得
    }
}
