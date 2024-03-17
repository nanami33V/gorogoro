using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    RectTransform arrow;
    BallCtrl ball;

    [Header("–îˆó‚Ì‘å‚«‚³")]
    public float magnification;

    private Vector2 set = Vector2.up;
    private float Z, scaleY;


    void Start()
    {
        arrow = GetComponent<RectTransform>();
        ball = FindObjectOfType<BallCtrl>();


    }

    void Update()
    {
        /*
        if (ball.isTap == false)
        {
            scale.y = 0;
        }
        else
        {
            arrow.localScale.y = ball.startDirectione * magnification;
            scale.x = 1f;
        }
        arrow.localScale = scale;

        Z = Vector2.SignedAngle(ball.NONnormalized, set);
        arrow.rotation = Quaternion.Euler(0, 0, -Z);
        //Debug.Log(-Z+90);
        */
    }
}