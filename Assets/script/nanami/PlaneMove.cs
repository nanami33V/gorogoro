using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    public GameObject Plane;
    private GameObject[] step = new GameObject[100];
    float timer = 0;
    float spowntime = 2; //2ïbÇ≤Ç∆Ç…ê∂ê¨Ç≥ÇπÇÈ
    float posX = 10;
    float posY = -2;
    int planesize = 8;

    // Start is called before the first frame update
    void Start()
    {
        var parent = this.transform;
        for (int i = 0; i < step.Length; i++)
        {
            posX += Random.Range(planesize + 3, planesize + 9);
            posY += Random.Range(-3, 3);
            if (posY > 7){
                posY = 7;
            }else if(posY < -3) { 
                posY = -3; 
            } 
            step[i] = Instantiate(Plane, new Vector3(posX , posY, 0), Quaternion.identity,parent);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlaneGenerate()
    {
        var parent = this.transform;
        Instantiate(Plane, new Vector3(20, 0, 0), Quaternion.identity,parent);
    }
}
