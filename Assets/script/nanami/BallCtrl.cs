using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour
{
    [Header("�����x")]
    public Vector2 startSpeed = new Vector2(0.0f, 0.0f);

    [Header("���x����")]
    public float LimitSpeed;

    [Header("���˔{��")]
    public float magnification;

    Rigidbody2D rb2d;
    public groundCheck ground;

    OutCheck outcheck;
    Vector2 startPos, endPos;

    private Vector2 startDirection;

    private bool isGround;
    private bool isTap;

    bool DoPlay = false;

    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        outcheck = FindObjectOfType<OutCheck>();

        rb2d.AddForce(startSpeed);

    }

    void Update()
    {
        isGround = ground.isGround;
        
        if (isGround)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
                isTap = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                endPos = Input.mousePosition;
                startDirection = -1 * (endPos - startPos).normalized;

                rb2d.AddForce(startDirection * magnification);
                
                isTap = false;
            }
        }

        //���x����
        if (rb2d.velocity.x > LimitSpeed)
        {
            rb2d.velocity = new Vector2(LimitSpeed, rb2d.velocity.y);
        }

        //����������~�߂�
        if (outcheck.reset)
        {
            rb2d.velocity = new Vector2(0f, 0f);
            outcheck.reset = false;
        }

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