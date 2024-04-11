using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlTime : MonoBehaviour
{
	Rigidbody2D rigi;
	public groundCheck ground;
	public distanceScriptTime distanceTime;
	public GameManager gameManager;

	[Header("ジャンプ回数")]
	public int maxJumpCount = 2;
	private int JumpCount=0;

	//マウスのクリックを押したときと離したところの位置関係
	Vector2 startPos, endPos;

	//取得した距離、開始時のスピード、ジャンプの大きさ設定
	public Vector2 startDirection, startSpeed,jumpSize;
	//スピード管理、矢印の長さによって飛ぶ速度を変更するときの飽和曲線を調整
	public float LimitSpeedx, LimitSpeedy,tei;

	//設置しているか
	private bool isGround = false;

	//倍率の調整
	private float HowLong;
	//押されてるかの判定
	public bool tap=false;
	public bool Timetap = false;

	//復活時の土台
	public GameObject Reprefab;
	//ゴール設定
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
	//gameover判定
	private void OnTriggerEnter2D(Collider2D collision)
	{
		//timeAttackの時に落ちた時の処理
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
	void ControlBall()//ballを制御
    {
		if (gameManager.DoPlay == true)
		{
			if (isGround == true || JumpCount < maxJumpCount)
			{
				if (isGround == true) JumpCount = 0;

				if (Input.GetMouseButtonDown(0))//押された判定取得
				{
					startPos = Input.mousePosition;
					startDirection = new Vector2(0, 0);
					tap = true;
				}
				else if (Input.GetMouseButton(0))//ベクトルの大きさ情報を取得
				{
					endPos = Input.mousePosition;
					startDirection = -1 * (endPos - startPos);
				}
				else if (Input.GetMouseButtonUp(0))//離したときの処理
				{
					if (startDirection.magnitude > 0) HowLong = Mathf.Log(startDirection.magnitude, tei);//飽和して上限がある計算
					Vector2 shousai = new Vector2(startDirection.normalized.x * jumpSize.x, startDirection.normalized.y * jumpSize.y);
					if (gameManager.DoPlayTime == true) rigi.AddForce(shousai * HowLong);
					JumpCount++;
					tap = false;
				}
				//Debug.Log(JumpCount);
			}
		}
	}
	void LimitSpeed()//速度制限（xが速すぎると描画できない速度になってしまう、yが小さすぎると矢印で変化するジャンプ量の差が亡くなってしまう）
	{
		if (rigi.velocity.x > LimitSpeedx) rigi.velocity = new Vector2(LimitSpeedx, rigi.velocity.y);
		if (-rigi.velocity.x > LimitSpeedx) rigi.velocity = new Vector2(-LimitSpeedx, rigi.velocity.y);
		if (rigi.velocity.y > LimitSpeedy) rigi.velocity = new Vector2(rigi.velocity.x, LimitSpeedy);
	}
	void GoalManager()//Goal時の処理
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