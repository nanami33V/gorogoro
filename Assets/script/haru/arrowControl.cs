using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowControl : MonoBehaviour
{
    RectTransform arrowRect;
    BallControl ball;

    [Header("矢印の大きさ")]
    public float magnification;

    private float z;

    void Start()
    {
        arrowRect = GetComponent<RectTransform>();
        ball = FindObjectOfType<BallControl>();
    }

    void Update()
    {
        if (ball.tap)//画面を押されている間、押し始めた場所から現在押している場所の距離で矢印の長さ変化
        {
            arrowRect.localScale = new Vector2(1.0f, ball.startDirection.magnitude * magnification);
        }
        else//画面を離したら矢印を見えなくする
        {
            arrowRect.localScale = Vector2.zero;
        }

        z = Vector2.SignedAngle(Vector2.up, ball.startDirection);//角度を判定
        arrowRect.rotation = Quaternion.Euler(0, 0, z);
    }
}
