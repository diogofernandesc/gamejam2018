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
	public int startingHealth;
	public int health;
	public SpriteRenderer healthBarSprite;
	public PlayerControlled pc;
	public GameController gameController;
	GameObject[] players;

	// Use this for initialization
	void Start () {
		this.moveSpeed = 5f;
		this.turnSpeed = 5f;
		this.health = 5;
	}

	void Update() {
  }

	void LateUpdate() {
		gameController = GameObject.Find ("Main Camera").GetComponent<GameController> ();
		gameController.UpdateHealthBarSprite (this, healthBarSprite);

		if (this.health <= 0) {
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Moving and steering
		float hmov = pc.getHMove();
		float vmov = pc.getVMove();
		float absoluteMoveSpeed = Mathf.Sqrt(hmov * hmov + vmov * vmov) * this.moveSpeed;
		this.rb2d.rotation = Mathf.Atan2 (vmov, hmov) * Mathf.Rad2Deg;
		Vector2 mov = new Vector2(absoluteMoveSpeed * Mathf.Cos(this.rb2d.rotation * Mathf.Deg2Rad), absoluteMoveSpeed * Mathf.Sin(this.rb2d.rotation * Mathf.Deg2Rad));
		this.rb2d.velocity = mov;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			if (this.health < startingHealth) {
				this.health += 1;
			}
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
