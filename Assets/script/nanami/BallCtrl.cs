using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour
{
    [Header("初速度")]
    public Vector2 startSpeed = new Vector2(0.0f, 0.0f);

    [Header("速度制限")]
    public float LimitSpeed = 1;

    [Header("発射倍率")]
    public float magnification = 1;

    [Header("ジャンプ回数")]
    public int maxJumpCount= 2;

    [SerializeField] GameManager gameManager;
    Rigidbody2D rb2d;
    public Ground ground;

    //// //;
    Vector2 startPos, endPos;

    public Vector2 startDirection;

    public bool isTap = false;

    int jumpCount = 0;
    public bool isGround;
    bool DoPlay = true;

    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // = FindObjectOfType<//>();
        //Application.targetFrameRate = 30;
        rb2d.AddForce(startSpeed);

    }

    void Update()
    {
        isGround = ground.isGround;

        if (DoPlay == true)
        {
            if (isGround && jumpCount < maxJumpCount)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    startPos = Input.mousePosition;
                    isTap = true;
                }
                else if (Input.GetMouseButton(0))//arrowに送るために毎フレーム計算
                {
                    endPos = Input.mousePosition;
                    startDirection = -1 * (endPos - startPos);
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    rb2d.AddForce(startDirection.normalized * magnification);
                    jumpCount++;
                    isTap = false;
                }
            }
        }

        //速度制限
        if (rb2d.velocity.x > LimitSpeed)
        {
            rb2d.velocity = new Vector2(LimitSpeed, rb2d.velocity.y);
        }
        
        /*
        //落下したら止める
        if (//.reset)
        {
            rb2d.velocity = new Vector2(0f, 0f);
            //.reset = false;
        }
        */

    }
    private IEnumerator PlayDo() // 操作を可能にする
    {
        DoPlay = true;
        yield break;
    }

    public void CallPlayDo()
    {
        StartCoroutine("PlayDo"); // 他のスクリプトから呼び出す用
    }
}