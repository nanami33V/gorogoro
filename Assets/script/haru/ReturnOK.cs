using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ReturnOK : MonoBehaviour
{
    public GameObject returnDisplay;//表示するかしないか決めるgameObj

    [SerializeField]
    Image ClickImage;

    //一つのスクリプトでいくつかの効果を持たせたかったためLISTでまとめている
    [Header("表示するか消すか選択してください")]
    public JobList returnKinds;  //列挙型の値を格納する変数

    public enum JobList
    {
        TRUE, FALSE
    }
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
