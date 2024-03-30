using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] UIManager UIManager;
    public distanceScript distance;
    private void Start()
    {
        Debug.Log("カウントダウン開始");
        UIManager.animNum5();
    }
    public void callGet1()
    {
        UIManager.animNum1();
    }
    public void callGet2()
    {
        UIManager.animNum2();
    }
    public void callGet3()
    {
        UIManager.animNum3();
    }
    public void callGet4()
    {
        UIManager.animNum4();
        distance.Callstart();

    }
}
