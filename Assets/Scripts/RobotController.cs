using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Triggered at these brackets
public class RobotController : MonoBehaviour {

	public Rigidbody2D rb2d;
<<<<<<< HEAD:Assets/Scripts/RobotController.cs
	public float speed;
	public int health;

	// Use this for initialization
	void Start () {
		health = 5;
=======
	public float moveSpeed;
	public float turnSpeed;

	// Use this for initialization
	void Start () {
		this.moveSpeed = 5f;
		this.turnSpeed = 5f;
>>>>>>> f7a7d85ad90dd79452a0e1cd7da1f812ce2561fc:Assets/RobotController.cs
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Moving and steering
		float absoluteMoveSpeed = Input.GetAxis ("Vertical") * this.moveSpeed;
		Vector2 mov = new Vector2(absoluteMoveSpeed * Mathf.Cos(this.transform.eulerAngles.z * Mathf.Deg2Rad), absoluteMoveSpeed * Mathf.Sin(this.transform.eulerAngles.z * Mathf.Deg2Rad));
		this.rb2d.velocity = mov;
		this.rb2d.MoveRotation (this.transform.eulerAngles.z + (Input.GetAxis ("Horizontal") * -this.turnSpeed));
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			health += 1;
			other.gameObject.SetActive (false);
		}
//		} else if (other.gameObject.CompareTag ("Enemy")) {
//			health -= 1;
//			Vector2 jumpForce = new Vector2(1,1);
//			rb2d.AddForce (jumpForce, ForceMode2D.Impulse);
//		}
	}
		
}
