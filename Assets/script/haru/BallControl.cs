using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
	[SerializeField] GameManager gameManager;
	Rigidbody2D rigi;

	Vector2 startPos, endPos;
	public Vector2 startDirection, NONnormalized, startSpeed;
	public float speedX,speedY, LimitSpeed,tei;

	public groundCheck ground;
	private bool isGround = false,canJamp=false;
	private float HowLong;

	public bool tap=false;
	bool DoPlay = false;

	void Start()
	{
		rigi = GetComponent<Rigidbody2D>();

		gameManager.GameOverStop();
		rigi.AddForce(startSpeed);
	}

	void Update()
	{
		
		ground.IsGround();
		isGround = ground.isGround;
		//Debug.Log(DoPlay);
		if(DoPlay==true)
        {

			if (canJamp == false & isGround)
			{
				canJamp = true;
			}
			// �}�E�X�̓����Ɣ��Ε����ɔ��˂����
			if (canJamp == true)
			{
				if (Input.GetMouseButtonDown(0))
				{
					startPos = Input.mousePosition;
					tap = true;
				}
				else if (Input.GetMouseButton(0))
				{
					endPos = Input.mousePosition;
					startDirection = -1 * (endPos - startPos).normalized;
					NONnormalized = -1 * (endPos - startPos);
				}
				else if (Input.GetMouseButtonUp(0))
				{
					if (NONnormalized.magnitude > 0) HowLong = Mathf.Log(NONnormalized.magnitude, tei);
					Vector2 shousai = new Vector2(startDirection.x * speedX, startDirection.y * speedY);
					rigi.AddForce(shousai * HowLong);
					canJamp = false;
					tap = false;
				}
			}
		}
		

		//���x����
		if(rigi.velocity.x>LimitSpeed)
		{ 
			rigi.velocity = new Vector2(LimitSpeed, rigi.velocity.y);
		}
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