using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    [SerializeField]Image ClickImage;

    // ���[�h�̐i���󋵂�\������UI�Ȃ�
    public GameObject loadingUI;

    // ���[�h�̐i���󋵂��Ǘ����邽�߂̕ϐ�
    private AsyncOperation async;
    
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
        Debug.Log("click");
        ReStartThisScene();
        //StartCoroutine(Load());
    }
    /*private IEnumerator Load()
    {
        // ���[�h��ʂ�\������
        loadingUI.SetActive(true);

        // �V�[����񓯊��Ń��[�h����
        async = SceneManager.LoadSceneAsync(sceneName);

        // ���[�h����������܂őҋ@����
        while (!async.isDone)
        {
            yield return null;
        }

        // ���[�h��ʂ��\���ɂ���
        loadingUI.SetActive(false);
    }*/
    void ReStartThisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
