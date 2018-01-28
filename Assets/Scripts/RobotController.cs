using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//Triggered at these brackets
public class RobotController : MonoBehaviour {

	public Rigidbody2D rb2d;
	public float speed;
	public float moveSpeed;
	public float turnSpeed;
	public int health;
	public SpriteRenderer healthBarSprite;
	public PlayerControlled pc;
	public GameController gameController;

	// Use this for initialization
	void Start () {
		this.moveSpeed = 5f;
		this.turnSpeed = 5f;
		this.health = 5;
	}

	void Update() {
		if (this.health == 0) {
			Destroy (this.gameObject);
			Text gameOverText = GameObject.Find ("GameOverText").GetComponent<Text> ();
			gameOverText.enabled = true;	
		}

		gameController = GameObject.Find ("Main Camera").GetComponent<GameController> ();
		gameController.UpdateHealthBarSprite (this, healthBarSprite);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Moving and steering
		float absoluteMoveSpeed = pc.moveAmount() * this.moveSpeed;
		Vector2 mov = new Vector2(absoluteMoveSpeed * Mathf.Cos(this.transform.eulerAngles.z * Mathf.Deg2Rad), absoluteMoveSpeed * Mathf.Sin(this.transform.eulerAngles.z * Mathf.Deg2Rad));
		this.rb2d.velocity = mov;
		this.rb2d.MoveRotation (this.transform.eulerAngles.z + (pc.turnAmount() * -this.turnSpeed));
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			this.health += 1;
			other.gameObject.SetActive (false);
			gameController = GameObject.Find ("Main Camera").GetComponent<GameController> ();
			gameController.updateScore (1);
		} //else if (other.gameObject.CompareTag ("Enemy")) {
			//health -= 1;
			//Vector2 jumpForce = new Vector2(1,1);
			//rb2d.AddForce (jumpForce, ForceMode2D.Impulse)
		//}
	}
		
}
