using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVol : MonoBehaviour
{
    //��̃X�N���v�g�ł������̌��ʂ�������������������LIST�ł܂Ƃ߂Ă���
    [Header("�ǂ���𒲐߂��邩�I�����Ă�������")]
    public JobList AudioKinds;  //�񋓌^�̒l���i�[����ϐ�

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
