using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class scoreReset : MonoBehaviour
{
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("�S�Ẵf�[�^���폜����܂���");
        }
    }
    
}
