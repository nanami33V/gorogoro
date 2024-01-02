using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.SceneManagement;

public class aaa : MonoBehaviour
{

    [SerializeField]
    Image ClickImage;

    void Start()
    {
        EventTrigger trigger = ClickImage.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();

        // なんのイベントを検出するか
        entry.eventID = EventTriggerType.PointerClick;
        // コールバック登録
        entry.callback.AddListener(Clicked);

        // EventTriggerに追加
        trigger.triggers.Add(entry);

    }

    void Clicked(BaseEventData eventData)
    {
        //click時の処理
        Debug.Log("Clicked");
        SceneManager.LoadScene("StageTest");
    }
}