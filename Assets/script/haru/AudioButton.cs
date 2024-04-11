using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    //一つのスクリプトでいくつかの効果を持たせたかったためLISTでまとめている
    [Header("どちらを調節するか選択してください")]
    public JobList AudioKinds;  //列挙型の値を格納する変数
    public MathList MathKinds;

    public SoundManager sound;
    public enum JobList
    {
       BGM,SE
    }
    public enum MathList
    {
        minus,plus
    }

    public void OnClickButton()
    {
        if (AudioKinds == JobList.BGM)
        {
            if (MathKinds == MathList.plus && sound.BGMvol < 100) sound.BGMvol++;
            if (MathKinds == MathList.minus && 0 < sound.BGMvol) sound.BGMvol--;
        }
        if (AudioKinds == JobList.SE )
        {
            if (MathKinds == MathList.plus && sound.SEvol < 100) sound.SEvol++;
            if (MathKinds == MathList.minus && 0 < sound.SEvol) sound.SEvol--;
        }
    }
   
}
