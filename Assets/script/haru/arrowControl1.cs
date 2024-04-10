using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowControl1 : MonoBehaviour
{
    RectTransform arrowRect;
    BallControlTime ball;

    [Header("���̑傫��")]
    public float magnification;

    private float z;

    void Start()
    {
        arrowRect = GetComponent<RectTransform>();
        ball = FindObjectOfType<BallControlTime>();
    }

    void Update()
    {
        if (ball.tap)//��ʂ�������Ă���ԁA�����n�߂��ꏊ���猻�݉����Ă���ꏊ�̋����Ŗ��̒����ω�
        {
            arrowRect.localScale = new Vector2(1.0f, ball.startDirection.magnitude * magnification);
        }
        else//��ʂ𗣂�������������Ȃ�����
        {
            arrowRect.localScale = Vector2.zero;
        }

        z = Vector2.SignedAngle(Vector2.up, ball.startDirection);//�p�x�𔻒�
        arrowRect.rotation = Quaternion.Euler(0, 0, z);
    }
}
