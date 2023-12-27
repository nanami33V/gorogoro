using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class aaa : MonoBehaviour
{

    [SerializeField]
    Image ClickImage;

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

    }

    void Clicked(BaseEventData eventData)
    {
        //click���̏���
        Debug.Log("Clicked");
    }
}