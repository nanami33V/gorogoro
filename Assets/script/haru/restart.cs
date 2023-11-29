using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject StartPoint;

    public GameObject main;

    Vector2 stPos;



    void Start()
    {
        stPos=StartPoint.transform.position;
    }

    public void OnClick()
    {
        Time.timeScale = 1;
        main.transform.position = new Vector2(stPos.x,stPos.y);
        GameOver.SetActive(false);
    }


}
