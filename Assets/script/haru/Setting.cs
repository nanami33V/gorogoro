using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject settingDisplay;

    //��̃X�N���v�g�ł������̌��ʂ�������������������LIST�ł܂Ƃ߂Ă���
    [Header("�\�����邩�������I�����Ă�������")]
    public JobList SettingKinds;  //�񋓌^�̒l���i�[����ϐ�

    public enum JobList
    {
        TRUE, FALSE
    }
    private void Start()
    {
        settingDisplay.SetActive(false);
    }
    //�ݒ��\���A��\��
    public void OnClickButton()
    {
        if(SettingKinds==JobList.TRUE) settingDisplay.SetActive(true);
        if (SettingKinds == JobList.FALSE) settingDisplay.SetActive(false);
    }
}
