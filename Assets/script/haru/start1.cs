using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start1 : MonoBehaviour
{
    public GameManager gameManager;
    public distanceScriptTime distance;
    private void Start()
    {
        Debug.Log("�J�E���g�_�E���J�n");
        gameManager.StartActiveTrue();
        gameManager.animNum3();
    }
    //animation�̒��ɃZ�b�g����
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
        gameManager.DoPlayTime = true;
        distance.Callstart();
    }
}
