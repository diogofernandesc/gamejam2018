using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Rigidbody2D rb2d;
	public int health;

	// Use this for initialization
	void Start () {
		this.health = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.health == 0)
			Destroy (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D col) {
		RobotController rc = col.gameObject.GetComponent<RobotController> ();
		if (rc != null) {
			rc.health -= 1;

			Vector2 jumpForce = new Vector2 (-20, -20);
			rb2d.AddForce (jumpForce);
		}
	}
}
