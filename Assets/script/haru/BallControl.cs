using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
	[SerializeField] GameManager gameManager;
	Rigidbody2D rigi;
	public groundCheck ground;

	[Header("�W�����v��")]
	public int maxJumpCount = 2;
	private int JumpCount=0;

	//�}�E�X�̃N���b�N���������Ƃ��Ɨ������Ƃ���̈ʒu�֌W
	Vector2 startPos, endPos;

	//�擾���������A�J�n���̃X�s�[�h�A�W�����v�̑傫���ݒ�
	public Vector2 startDirection, startSpeed,jumpSize;
	//�X�s�[�h�Ǘ��A���̒����ɂ���Ĕ�ԑ��x��ύX����Ƃ��̖O�a�Ȑ��𒲐�
	public float LimitSpeed,tei;

	//�ݒu���Ă��邩
	private bool isGround = false;

	//�{���̒���
	private float HowLong;
	//������Ă邩�̔���
	public bool tap=false;
	//�������Ă������ǂ����̔���
	bool DoPlay = false;

	void Start()
	{
		rigi = GetComponent<Rigidbody2D>();

		gameManager.GameOverStop();
		rigi.AddForce(startSpeed);
	}

	void Update()
	{
		Debug.Log(JumpCount);
		ground.IsGround();
		isGround = ground.isGround;
		//Debug.Log(DoPlay);
		if(DoPlay==true)
        {
			if(isGround==true||JumpCount<maxJumpCount)
            {
				if (isGround == true|| JumpCount >= maxJumpCount) JumpCount = 0;

				if (Input.GetMouseButtonDown(0))//�����ꂽ����擾
				{
					startPos = Input.mousePosition;
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
		
		//���x����
		if(rigi.velocity.x>LimitSpeed) rigi.velocity = new Vector2(LimitSpeed, rigi.velocity.y);
		if (rigi.velocity.y > LimitSpeed) rigi.velocity = new Vector2(rigi.velocity.x, LimitSpeed);
	}
	//gameover����
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Out"))
		{
			gameManager.GameOver();
			this.gameObject.SetActive(false);
		}
	}
	//�������Ă������ǂ���
	private IEnumerator PlayDo() // ������\�ɂ���
	{
		DoPlay = true;
		yield break;
	}
	//PlayDo���N�����邽�߂̂���
	public void CallPlayDo()
	{
		StartCoroutine("PlayDo"); // ���̃X�N���v�g����Ăяo���p
	}
}