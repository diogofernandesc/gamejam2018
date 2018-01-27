using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Triggered at these brackets
public class RobotController : MonoBehaviour {

	public Rigidbody2D rb2d;
	public float moveSpeed;
	public float turnSpeed;

	// Use this for initialization
	void Start () {
		this.moveSpeed = 5f;
		this.turnSpeed = 5f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Moving and steering
		float absoluteMoveSpeed = Input.GetAxis ("Vertical") * this.moveSpeed;
		Vector2 mov = new Vector2(absoluteMoveSpeed * Mathf.Cos(this.transform.eulerAngles.z * Mathf.Deg2Rad), absoluteMoveSpeed * Mathf.Sin(this.transform.eulerAngles.z * Mathf.Deg2Rad));
		this.rb2d.velocity = mov;
		this.rb2d.MoveRotation (this.transform.eulerAngles.z + (Input.GetAxis ("Horizontal") * -this.turnSpeed));
	}
}
