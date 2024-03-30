using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour
{
    [Header("�����x")]
    public Vector2 startSpeed = new Vector2(0.0f, 0.0f);

    [Header("���x����")]
    public float LimitSpeed = 1;

    [Header("���˔{��")]
    public float magnification = 1;

    [Header("�W�����v��")]
    public int maxJumpCount= 2;

    Rigidbody2D rb2d;
    public groundCheck ground;

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
        
        if (isGround && jumpCount < maxJumpCount)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
                isTap = true;
            }
            else if (Input.GetMouseButton(0))//arrow�ɑ��邽�߂ɖ��t���[���v�Z
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

        //���x����
        if (rb2d.velocity.x > LimitSpeed)
        {
            rb2d.velocity = new Vector2(LimitSpeed, rb2d.velocity.y);
        }
        
        /*
        //����������~�߂�
        if (//.reset)
        {
            rb2d.velocity = new Vector2(0f, 0f);
            //.reset = false;
        }
        */

    }
    private IEnumerator PlayDo() // ������\�ɂ���
    {
        DoPlay = true;
        yield break;
    }

    public void CallPlayDo()
    {
        StartCoroutine("PlayDo"); // ���̃X�N���v�g����Ăяo���p
    }
}