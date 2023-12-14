using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutCheck : MonoBehaviour
{
    public GameObject GameOver;
    public bool reset=false;
    void Start()
    {
        GameOver.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MainObj"))
        {
            GameOver.SetActive(true);
            reset = true;
            Time.timeScale = 0;
        }
    }
}
