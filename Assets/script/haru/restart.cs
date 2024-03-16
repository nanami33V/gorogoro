using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    [SerializeField]Image ClickImage;

    // ロードの進捗状況を表示するUIなど
    public GameObject loadingUI;

    // ロードの進捗状況を管理するための変数
    private AsyncOperation async;
    
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
        Debug.Log("click");
        ReStartThisScene();
        //StartCoroutine(Load());
    }
    /*private IEnumerator Load()
    {
        // ロード画面を表示する
        loadingUI.SetActive(true);

        // シーンを非同期でロードする
        async = SceneManager.LoadSceneAsync(sceneName);

        // ロードが完了するまで待機する
        while (!async.isDone)
        {
            yield return null;
        }

        // ロード画面を非表示にする
        loadingUI.SetActive(false);
    }*/
    void ReStartThisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
