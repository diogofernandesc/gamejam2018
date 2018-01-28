using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Rigidbody2D rb2d;
	public int health;
	public float speed = 2f;
	private GameObject playerToUse;
	GameObject[] players;
	// Use this for initialization
	void Start () {
		this.health = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.health == 0) {
			Destroy (this.gameObject);
      		return;
   		}
		players = GameObject.FindGameObjectsWithTag ("Player");

		if (players.Length == 1) {
			playerToUse = players [0];

		} else if (players.Length == 2) {
			float distanceToPlayer1 = Vector2.Distance (transform.position, players[0].transform.position);
			float distanceToPlayer2 = Vector2.Distance (transform.position, players[1].transform.position);

			// Finds closest player and chases them instead
			if ((Mathf.Min(distanceToPlayer1, distanceToPlayer2)) == distanceToPlayer2) {
				playerToUse = players[1];
			} 
		}

		if (playerToUse != null) {
			transform.position = Vector2.MoveTowards (transform.position, playerToUse.transform.position, speed * Time.deltaTime);		
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		
		RobotController rc = col.gameObject.GetComponent<RobotController> ();
		if (rc != null) {
			rc.health -= 1;

		}
	}
}
