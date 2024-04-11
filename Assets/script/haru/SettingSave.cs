using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingSave : MonoBehaviour
{
    public SoundManager soundManager;
    [SerializeField] TextMeshProUGUI BGMvolText;
    [SerializeField] TextMeshProUGUI SEvolText;
    //設定を保存するため
    public void OnClickButton()
    {
        PlayerPrefs.SetFloat("BGMVOL", soundManager.BGMvol);
        PlayerPrefs.SetFloat("SEVOL", soundManager.SEvol);
        PlayerPrefs.Save();
    }

    //スクリプトを増やさなくてもいいように使用と思い、ここに音量表示
    private void Update()
    {
        BGMvolText.text = soundManager.BGMvol.ToString();
        SEvolText.text = soundManager.SEvol.ToString();
    }
}
