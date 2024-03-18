using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    RectTransform arrow;
    BallCtrl ballctrl;

    [Header("–îˆó‚Ì‘å‚«‚³")]
    public float magnification;

    private Vector2 scale;
    private float z;


    void Start()
    {
        arrow = GetComponent<RectTransform>();
        ballctrl = FindObjectOfType<BallCtrl>();
    }

    void Update()
    {
        if (ballctrl.isTap)
        {
            arrow.localScale = new Vector2(1.0f, ballctrl.startDirection.magnitude * magnification);
        }
        else
        {
            arrow.localScale = Vector2.zero;
        }

        z = Vector2.SignedAngle(Vector2.up, ballctrl.startDirection);
        arrow.rotation = Quaternion.Euler(0, 0, z);
        
    }
}