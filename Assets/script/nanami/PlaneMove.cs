using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    public GameObject[] Plane;
    public GameObject Maru;
    private GameObject[] step = new GameObject[5];
    private GameObject[] poststep = new GameObject[5];
    float posX = 10;
    float postposX = 200;
    float posY = -2;
    int planesize = 8;
    bool lastplane = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlaneGenerate();
    }

    void PlaneGenerate()
    {
        var MpointX = Maru.transform.position.x;
        var parent = this.transform;
        int nowplane = 0;

        if (posX - 10 < MpointX)
        {
            lastplane = true;
            postposX = posX;
            for (int i = 0; i < step.Length; i++)
            {
                int selectplane = Random.Range(0, 100);
                if (selectplane < 50)
                {
                    nowplane = 0;
                }
                else if (selectplane < 70)
                {
                    nowplane = 1;
                }
                else if (selectplane < 100)
                {
                    nowplane = 2;
                }
                poststep[i] = step[i];
                posX += Random.Range(planesize + 3, planesize + 9);
                posY += Random.Range(-3, 3);
                if (posY > 7)
                {
                    posY = 7;
                }
                else if (posY < -3)
                {
                    posY = -3;
                }
                step[i] = Instantiate(Plane[nowplane], new Vector3(posX, posY, 0), Quaternion.identity, parent);
            }
        }
        if (postposX + 10 < MpointX && lastplane && poststep != null)
        {
            lastplane = false;
            for (int i = 0; i < step.Length; i++)
            {
                Destroy(poststep[i].gameObject);
            }
        }
    }
}
