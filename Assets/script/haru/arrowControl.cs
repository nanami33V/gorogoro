using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowControl : MonoBehaviour
{
    RectTransform arrowRect;
    BallControl ball;

    [Header("–îˆó‚Ì‘å‚«‚³")]
    public float magnification;

    private float z;

    void Start()
    {
        arrowRect = GetComponent<RectTransform>();
        ball = FindObjectOfType<BallControl>();
    }

    void Update()
    {
        if (ball.tap)
        {
            arrowRect.localScale = new Vector2(1.0f, ball.startDirection.magnitude * magnification);
        }
        else
        {
            arrowRect.localScale = Vector2.zero;
        }

        z = Vector2.SignedAngle(Vector2.up, ball.startDirection);
        arrowRect.rotation = Quaternion.Euler(0, 0, z);
    }
}
