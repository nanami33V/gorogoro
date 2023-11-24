using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

	Rigidbody2D rigi;
	Vector2 startPos, endPos;
	public Vector2 startDirection, NONnormalized;
	public float speed;


	void Start()
	{
		rigi = GetComponent<Rigidbody2D>();
	}

	void Update()
	{

		// ƒ}ƒEƒX‚Ì“®‚«‚Æ”½‘Î•ûŒü‚É”­ŽË‚³‚ê‚é
		if (Input.GetMouseButtonDown(0))
		{
			startPos = Input.mousePosition;
		}
		else if (Input.GetMouseButton(0))
		{
			endPos = Input.mousePosition;
			startDirection = -1 * (endPos - startPos).normalized;
			NONnormalized = -1 * (endPos - startPos);
		}
		else if (Input.GetMouseButtonUp(0))
		{
			rigi.AddForce(startDirection * speed);
		}
	}
}