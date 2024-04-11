using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ReturnOK : MonoBehaviour
{
    public GameObject returnDisplay;//�\�����邩���Ȃ������߂�gameObj

    [SerializeField]
    Image ClickImage;

    //��̃X�N���v�g�ł������̌��ʂ�������������������LIST�ł܂Ƃ߂Ă���
    [Header("�\�����邩�������I�����Ă�������")]
    public JobList returnKinds;  //�񋓌^�̒l���i�[����ϐ�

    public enum JobList
    {
        TRUE, FALSE
    }
    void Start()
    {
        EventTrigger trigger = ClickImage.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();

        // �Ȃ�̃C�x���g�����o���邩
        entry.eventID = EventTriggerType.PointerClick;
        // �R�[���o�b�N�o�^
        entry.callback.AddListener(Clicked);

        // EventTrigger�ɒǉ�
        trigger.triggers.Add(entry);

        returnDisplay.SetActive(false);
    }

    void Clicked(BaseEventData eventData)
    {
        if (returnKinds == JobList.TRUE)
        {
            returnDisplay.SetActive(true);
            Time.timeScale = 0;
        }
        if (returnKinds == JobList.FALSE)
        {
            returnDisplay.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
