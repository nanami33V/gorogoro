using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
	[SerializeField] GameManager gameManager;
	Rigidbody2D rigi;
	public groundCheck ground;

	[Header("ジャンプ回数")]
	public int maxJumpCount = 2;
	private int JumpCount=0;

	//マウスのクリックを押したときと離したところの位置関係
	Vector2 startPos, endPos;

	//取得した距離、開始時のスピード、ジャンプの大きさ設定
	public Vector2 startDirection, startSpeed,jumpSize;
	//スピード管理、矢印の長さによって飛ぶ速度を変更するときの飽和曲線を調整
	public float LimitSpeed,tei;

	//設置しているか
	private bool isGround = false;

	//倍率の調整
	private float HowLong;
	//押されてるかの判定
	public bool tap=false;
	//動かしていいかどうかの判定
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

				if (Input.GetMouseButtonDown(0))//押された判定取得
				{
					startPos = Input.mousePosition;
					tap = true;
				}
				else if (Input.GetMouseButton(0))//ベクトルの大きさ情報を取得
				{
					endPos = Input.mousePosition;
					startDirection = -1 * (endPos - startPos);
				}
				else if (Input.GetMouseButtonUp(0))//離したときの処理
				{
					if (startDirection.magnitude > 0) HowLong = Mathf.Log(startDirection.magnitude, tei);
					Vector2 shousai = new Vector2(startDirection.normalized.x * jumpSize.x, startDirection.normalized.y * jumpSize.y);
					rigi.AddForce(shousai * HowLong);
					JumpCount++;
					tap = false;
				}
			}
		}
		
		//速度制限
		if(rigi.velocity.x>LimitSpeed) rigi.velocity = new Vector2(LimitSpeed, rigi.velocity.y);
		if (rigi.velocity.y > LimitSpeed) rigi.velocity = new Vector2(rigi.velocity.x, LimitSpeed);
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
	//動かしていいかどうか
	private IEnumerator PlayDo() // 操作を可能にする
	{
		DoPlay = true;
		yield break;
	}
	//PlayDoを起動するためのもの
	public void CallPlayDo()
	{
		StartCoroutine("PlayDo"); // 他のスクリプトから呼び出す用
	}
}