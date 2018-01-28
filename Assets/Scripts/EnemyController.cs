using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Rigidbody2D rb2d;
	public int health;
	public float speed = 2f;
	private GameObject playerToUse;
	GameObject[] players;
	public GameObject player1;
	public GameObject player2;
	// Use this for initialization
	void Start () {
		this.health = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.health == 0) {
			Destroy (this.gameObject);
//      		return;
   		}
		player1 = GameObject.FindGameObjectWithTag ("Player");
		player2 = GameObject.FindGameObjectWithTag ("Player2");
//		players = GameObject.FindGameObjectsWithTag ("Player");
		if (player1 == null) {
			playerToUse = player2;
		
		} else if (player2 == null) {
			playerToUse = player1;

		} else {
			float distanceToPlayer1 = Vector2.Distance (transform.position, player1.transform.position);
			float distanceToPlayer2 = Vector2.Distance (transform.position, player2.transform.position);

			// Finds closest player and chases them instead
			if (distanceToPlayer1 > distanceToPlayer2) {
				playerToUse = player2;
			} else if (distanceToPlayer1 < distanceToPlayer2) {
				playerToUse = player1;
			}
		}

//		print (players.Length);
//		if (players.Length == 1) {
//			playerToUse = players [0];
//
//		} else {
//			float distanceToPlayer1 = Vector2.Distance (transform.position, players[0].transform.position);
//			float distanceToPlayer2 = Vector2.Distance (transform.position, players[1].transform.position);
//
//			print (distanceToPlayer1 + ", " + distanceToPlayer2);
//
//			// Finds closest player and chases them instead
//			if (distanceToPlayer1 > distanceToPlayer2) {
//				playerToUse = players[1];
//			} 
//		}
//
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
