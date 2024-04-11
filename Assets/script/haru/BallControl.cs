using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
	Rigidbody2D rigi;
	public groundCheck ground;
	public distanceScript distance;
	public GameManager gameManager;

	[Header("�W�����v��")]
	public int maxJumpCount = 2;
	private int JumpCount=0;

	//�}�E�X�̃N���b�N���������Ƃ��Ɨ������Ƃ���̈ʒu�֌W
	Vector2 startPos, endPos;

	//�擾���������A�J�n���̃X�s�[�h�A�W�����v�̑傫���ݒ�
	public Vector2 startDirection, startSpeed,jumpSize;
	//�X�s�[�h�Ǘ��A���̒����ɂ���Ĕ�ԑ��x��ύX����Ƃ��̖O�a�Ȑ��𒲐�
	public float LimitSpeedx, LimitSpeedy, tei;

	//�ݒu���Ă��邩
	private bool isGround = false;

	//�{���̒���
	private float HowLong;
	//������Ă邩�̔���
	public bool tap=false;

	void Start()
	{
		rigi = GetComponent<Rigidbody2D>();
		//�ŏ��ɃX�s�[�h��^����
		rigi.AddForce(startSpeed);
	}

	void Update()
	{
		isGround = ground.IsGround();//�n�ʂ̔���m�F
		ControlBall();
		LimitSpeed();
	}
	//gameover����
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Out"))
		{
			gameManager.GameOver();
			distance.SaveSt();
			this.gameObject.SetActive(false);
		}
	}
	void ControlBall()//ball�̐���
    {
		if (gameManager.DoPlay == true)
		{
			if (isGround == true || JumpCount < maxJumpCount)//�n�ʂɒ����Ă��āA�����ꂽ�W�����v���𒴂��Ă��Ȃ���
			{
				if (isGround == true || JumpCount >= maxJumpCount) JumpCount = 0;//�n�ʂɒ�������W�����v�������Z�b�g

				if (Input.GetMouseButtonDown(0))//�����ꂽ����擾
				{
					startPos = Input.mousePosition;
					startDirection = new Vector2(0, 0);
					tap = true;
				}
				else if (Input.GetMouseButton(0))//�x�N�g���̑傫�������擾
				{
					endPos = Input.mousePosition;
					startDirection = -1 * (endPos - startPos);
				}
				else if (Input.GetMouseButtonUp(0))//�������Ƃ��̏���
				{
					if (startDirection.magnitude > 0) HowLong = Mathf.Log(startDirection.magnitude, tei);
					Vector2 shousai = new Vector2(startDirection.normalized.x * jumpSize.x, startDirection.normalized.y * jumpSize.y);
					rigi.AddForce(shousai * HowLong);
					JumpCount++;
					tap = false;
				}
			}
		}
	}
	void LimitSpeed()//���x�����ix����������ƕ`��ł��Ȃ����x�ɂȂ��Ă��܂��Ay������������Ɩ��ŕω�����W�����v�ʂ̍����S���Ȃ��Ă��܂��j
	{
		if (rigi.velocity.x > LimitSpeedx) rigi.velocity = new Vector2(LimitSpeedx, rigi.velocity.y);
		if (-rigi.velocity.x > LimitSpeedx) rigi.velocity = new Vector2(-LimitSpeedx, rigi.velocity.y);
		if (rigi.velocity.y > LimitSpeedy) rigi.velocity = new Vector2(rigi.velocity.x, LimitSpeedy);
	}
}