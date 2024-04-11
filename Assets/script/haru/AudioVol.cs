using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVol : MonoBehaviour
{
    //一つのスクリプトでいくつかの効果を持たせたかったためLISTでまとめている
    [Header("どちらを調節するか選択してください")]
    public JobList AudioKinds;  //列挙型の値を格納する変数

    public enum JobList
    {
        BGM, SE
    }
    public AudioSource audioSource;
    public SoundManager soundManager;
    void Start()
    {
        if (AudioKinds == JobList.BGM) audioSource.volume = soundManager.BGMvol/100;
        if (AudioKinds == JobList.SE) audioSource.volume = soundManager.SEvol/100;
    }
    private void Update()
    {
        if (AudioKinds == JobList.BGM) audioSource.volume = soundManager.BGMvol / 100;
        if (AudioKinds == JobList.SE) audioSource.volume = soundManager.SEvol / 100;
    }
}
