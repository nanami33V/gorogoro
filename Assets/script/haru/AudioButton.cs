using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    //��̃X�N���v�g�ł������̌��ʂ�������������������LIST�ł܂Ƃ߂Ă���
    [Header("�ǂ���𒲐߂��邩�I�����Ă�������")]
    public JobList AudioKinds;  //�񋓌^�̒l���i�[����ϐ�
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
