using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Rigidbody2D rb2d;
	public int health;
	public float speed;
	private GameObject playerToUse;
	GameObject[] players;
	public GameObject player1;
	public GameObject player2;
	public int waveAmount;
	public GameController gameController;
	public EnemySpawnerScript script;

	// Use this for initialization
	void Start () {
		script = GameObject.FindGameObjectWithTag ("EnemySpawner").GetComponent<EnemySpawnerScript> ();
		this.health = script.health;
		this.waveAmount = 5;
		this.speed = script.speed;
		this.gameController = GameObject.Find ("Main Camera").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.health <= 0) {
			if (player1 != null) {
				player1.GetComponent<RobotController> ().killCount += 1;
			} else {
				player2.GetComponent<RobotController> ().killCount += 1;
			}
			gameController.updateScore (1);
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
