using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowControl : MonoBehaviour
{
    RectTransform rectTrans;
    BallControl ball;
    public float bairitu;
    private float Z,scaleY;

    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        ball = FindObjectOfType<BallControl>();
    }

    void Update()
    {
        scaleY = ball.NONnormalized.magnitude * bairitu;
        Vector2 scale = rectTrans.localScale;
        scale.x = 1f;
        scale.y = scaleY;
        rectTrans.localScale = scale;


        Z =new Vector2 ;
        rectTrans.rotation = Quaternion.Euler(0, 0, Z);
    }
}
