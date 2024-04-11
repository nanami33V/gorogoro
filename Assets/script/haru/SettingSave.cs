using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingSave : MonoBehaviour
{
    public SoundManager soundManager;
    [SerializeField] TextMeshProUGUI BGMvolText;
    [SerializeField] TextMeshProUGUI SEvolText;
    //�ݒ��ۑ����邽��
    public void OnClickButton()
    {
        PlayerPrefs.SetFloat("BGMVOL", soundManager.BGMvol);
        PlayerPrefs.SetFloat("SEVOL", soundManager.SEvol);
        PlayerPrefs.Save();
    }

    //�X�N���v�g�𑝂₳�Ȃ��Ă������悤�Ɏg�p�Ǝv���A�����ɉ��ʕ\��
    private void Update()
    {
        BGMvolText.text = soundManager.BGMvol.ToString();
        SEvolText.text = soundManager.SEvol.ToString();
    }
}
