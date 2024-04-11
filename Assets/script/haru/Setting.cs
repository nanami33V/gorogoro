using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject settingDisplay;

    //一つのスクリプトでいくつかの効果を持たせたかったためLISTでまとめている
    [Header("表示するか消すか選択してください")]
    public JobList SettingKinds;  //列挙型の値を格納する変数

    public enum JobList
    {
        TRUE, FALSE
    }
    private void Start()
    {
        settingDisplay.SetActive(false);
    }
    //設定を表示、非表示
    public void OnClickButton()
    {
        if(SettingKinds==JobList.TRUE) settingDisplay.SetActive(true);
        if (SettingKinds == JobList.FALSE) settingDisplay.SetActive(false);
    }
}
