using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    [SerializeField]GameManager gameManager;
    public distanceScript distance;
    private void Start()
    {
        gameManager.animNum5();
    }
    public void callGet1()
    {
        gameManager.animNum1();
    }
    public void callGet2()
    {
        gameManager.animNum2();
    }
    public void callGet3()
    {
        gameManager.animNum3();
    }
    public void callGet4()
    {
        gameManager.animNum4();
        distance.Callstart();
    }
    public void callGet6()
    {
        gameManager.animNum6();
    }
    public void callAcFalse()
    {
        gameManager.StartActiveFalse();
    }
}
