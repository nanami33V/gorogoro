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

	void LateUpdate()
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
			// マウスの動きと反対方向に発射される
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
		

		//速度制限
		if(rigi.velocity.x>LimitSpeed)
		{ 
			rigi.velocity = new Vector2(LimitSpeed, rigi.velocity.y);
		}
	}
	//gameover判定
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Out"))
		{
			gameManager.GameOver();
			this.gameObject.SetActive(false);
		}
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