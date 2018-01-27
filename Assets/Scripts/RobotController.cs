using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Triggered at these brackets
public class RobotController : MonoBehaviour {

	public Rigidbody2D rb2d;
	public float speed;
	public int health;

	// Use this for initialization
	void Start () {
		health = 5;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 mov = new Vector2(this.speed * Input.GetAxis ("Horizontal"), this.speed * Input.GetAxis ("Vertical"));
		this.rb2d.velocity = mov;
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
