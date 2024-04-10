using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowControl1 : MonoBehaviour
{
    RectTransform arrowRect;
    BallControlTime ball;

    [Header("–îˆó‚Ì‘å‚«‚³")]
    public float magnification;

    private float z;

    void Start()
    {
        arrowRect = GetComponent<RectTransform>();
        ball = FindObjectOfType<BallControlTime>();
    }

    void Update()
    {
        if (ball.tap)//‰æ–Ê‚ğ‰Ÿ‚³‚ê‚Ä‚¢‚éŠÔA‰Ÿ‚µn‚ß‚½êŠ‚©‚çŒ»İ‰Ÿ‚µ‚Ä‚¢‚éêŠ‚Ì‹——£‚Å–îˆó‚Ì’·‚³•Ï‰»
        {
            arrowRect.localScale = new Vector2(1.0f, ball.startDirection.magnitude * magnification);
        }
        else//‰æ–Ê‚ğ—£‚µ‚½‚ç–îˆó‚ğŒ©‚¦‚È‚­‚·‚é
        {
            arrowRect.localScale = Vector2.zero;
        }

        z = Vector2.SignedAngle(Vector2.up, ball.startDirection);//Šp“x‚ğ”»’è
        arrowRect.rotation = Quaternion.Euler(0, 0, z);
    }
}
