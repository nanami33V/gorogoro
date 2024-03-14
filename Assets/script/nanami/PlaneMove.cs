using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    public GameObject[] Planes;
    public GameObject Maru;
    public GameObject StartGround;

    private int chunkSize = 10;
    private GameObject[] ActiveChunk = new GameObject[10];
    private GameObject[] OldChunk = new GameObject[10];
    private int defaltPlanesScale = 8;
    private float checkPointX = 0.0f;
    private int planenum;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < chunkSize; i++) { ActiveChunk[i] = StartGround; }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Maru.transform.position.x > checkPointX)
        {
            if (OldChunk[0] != null) { DeleteChunk(); }
            for (int i = 0; i < chunkSize; i++) { OldChunk[i] = ActiveChunk[i]; }
            ChunkGenerate();
        }
        
    }

    void ChunkGenerate()
    {
        Debug.Log("�V�����`�����N�𐶐����܂�");
        //�E�[�ɂ���I�u�W�F�N�g�̉E��[�̍��W���擾
        float lastPointX = ActiveChunk[chunkSize - 1].transform.position.x + ActiveChunk[chunkSize - 1].transform.localScale.x / 2;
        float lastPointY = ActiveChunk[chunkSize - 1].transform.position.y + ActiveChunk[chunkSize - 1].transform.localScale.y / 2;

        for (int i = 0; i < chunkSize; i++)
        {
            int planeScale = Random.Range(defaltPlanesScale/2, defaltPlanesScale*2+1); //���̕���0.5�{�`2�{�܂Ń����_���ɕς���
            int holeSize = Random.Range(2, 10); //���̕�
            int planeHeight = Random.Range(-2, 2); //�����_���ɍ�����ς���

            int selectplane = Random.Range(0, 100);
            if (selectplane < 50)
            {
                planenum = 0;
            }
            else if (selectplane < 75)
            {
                planenum = 1;
            }
            else if (selectplane < 100)
            {
                planenum = 2;
            }

            //�E�[�̃I�u�W�F�N�g�ƐV���ɐ��������I�u�W�F�N�g��
            lastPointX += planeScale / 2 + holeSize;
            lastPointY -= Planes[0].transform.localScale.y / 2 + planeHeight;
            if (lastPointY < -10)
            {
                lastPointY += 2;
            }else if(lastPointY > -1)
            {
                lastPointY -= 2;
            }
            Debug.Log(lastPointY);
            ActiveChunk[i] = Instantiate(Planes[planenum], new Vector2(lastPointX, lastPointY), Quaternion.identity);
            ActiveChunk[i].transform.localScale = new Vector2(planeScale, ActiveChunk[i].transform.localScale.y);

            lastPointX = ActiveChunk[i].transform.position.x + ActiveChunk[i].transform.localScale.x / 2;
            lastPointY = ActiveChunk[i].transform.position.y + ActiveChunk[i].transform.localScale.y / 2;
        }
        
        checkPointX = ActiveChunk[chunkSize / 2].transform.position.x;
    }

    void DeleteChunk()
    {
        Debug.Log("�Â��`�����N�������܂�");
        for (int i = 0; i < chunkSize; i++) { Destroy(OldChunk[i].gameObject); }
    }
}
