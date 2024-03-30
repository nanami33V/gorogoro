using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    [SerializeField]GameManager gameManager;
    public distanceScript distance;
    private void Start()
    {
        Debug.Log("カウントダウン開始");
        gameManager.animNum3();
    }
    public void callGet1()
    {
        gameManager.animNum1();
    }
    public void callGet2()
    {
        gameManager.animNum2();
    }
    public void callGetGO()
    {
        gameManager.animNumGO();
    }
    public void callGetPlay()
    {
        gameManager.animNumPlay();
        distance.Callstart();
    }
    public void callAcFalse()
    {
        gameManager.StartActiveFalse();
    }
    public void callSE()
    {
        gameManager.CallSeGo();
    }
}
