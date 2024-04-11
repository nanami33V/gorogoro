using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlTime : MonoBehaviour
{
	Rigidbody2D rigi;
	public groundCheck ground;
	public distanceScriptTime distanceTime;
	public GameManager gameManager;

	[Header("�W�����v��")]
	public int maxJumpCount = 2;
	private int JumpCount=0;

	//�}�E�X�̃N���b�N���������Ƃ��Ɨ������Ƃ���̈ʒu�֌W
	Vector2 startPos, endPos;

	//�擾���������A�J�n���̃X�s�[�h�A�W�����v�̑傫���ݒ�
	public Vector2 startDirection, startSpeed,jumpSize;
	//�X�s�[�h�Ǘ��A���̒����ɂ���Ĕ�ԑ��x��ύX����Ƃ��̖O�a�Ȑ��𒲐�
	public float LimitSpeedx, LimitSpeedy,tei;

	//�ݒu���Ă��邩
	private bool isGround = false;

	//�{���̒���
	private float HowLong;
	//������Ă邩�̔���
	public bool tap=false;
	public bool Timetap = false;

	//�������̓y��
	public GameObject Reprefab;
	//�S�[���ݒ�
	public int GoalLine;
	void Start()
	{
		rigi = GetComponent<Rigidbody2D>();
		rigi.AddForce(startSpeed);
		Debug.Log("strat");
	}

	void Update()
	{
		isGround = ground.IsGround();
		ControlBall();
		LimitSpeed();
		GoalManager();
	}
	//gameover����
	private void OnTriggerEnter2D(Collider2D collision)
	{
		//timeAttack�̎��ɗ��������̏���
		if (collision.gameObject.CompareTag("Out"))
		{
			rigi.position = new Vector2(this.gameObject.transform.position.x, 3.5f);
			rigi.velocity = new Vector2(0, 0);
			Instantiate(Reprefab, new Vector2(this.gameObject.transform.position.x, 3), Quaternion.identity);
			gameManager.DoPlayTime = false;
			gameManager.StartActiveTrue();
			gameManager.animNum3();
		}
	}
	void ControlBall()//ball�𐧌�
    {
		if (gameManager.DoPlay == true)
		{
			if (isGround == true || JumpCount < maxJumpCount)
			{
				if (isGround == true) JumpCount = 0;

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
					if (startDirection.magnitude > 0) HowLong = Mathf.Log(startDirection.magnitude, tei);//�O�a���ď��������v�Z
					Vector2 shousai = new Vector2(startDirection.normalized.x * jumpSize.x, startDirection.normalized.y * jumpSize.y);
					if (gameManager.DoPlayTime == true) rigi.AddForce(shousai * HowLong);
					JumpCount++;
					tap = false;
				}
				//Debug.Log(JumpCount);
			}
		}
	}
	void LimitSpeed()//���x�����ix����������ƕ`��ł��Ȃ����x�ɂȂ��Ă��܂��Ay������������Ɩ��ŕω�����W�����v�ʂ̍����S���Ȃ��Ă��܂��j
	{
		if (rigi.velocity.x > LimitSpeedx) rigi.velocity = new Vector2(LimitSpeedx, rigi.velocity.y);
		if (-rigi.velocity.x > LimitSpeedx) rigi.velocity = new Vector2(-LimitSpeedx, rigi.velocity.y);
		if (rigi.velocity.y > LimitSpeedy) rigi.velocity = new Vector2(rigi.velocity.x, LimitSpeedy);
	}
	void GoalManager()//Goal���̏���
	{
		if (GameManager.instance.nowscore >= GoalLine)
		{
			Debug.Log("Goal");
			gameManager.Goal();
			distanceTime.SaveSt();
			this.gameObject.SetActive(false);
		}
	}

}