using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    public GameManager gameManager;
    public distanceScript distance;
    private void Start()
    {
        Debug.Log("カウントダウン開始");
        gameManager.animNum3();
    }
    //animationの中にセットする
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
    
    public void callAcFalse()
    {
        gameManager.StartActiveFalse();
    }
    public void callSE()
    {
        gameManager.CallSeGo();
        distance.Callstart();
    }
}
