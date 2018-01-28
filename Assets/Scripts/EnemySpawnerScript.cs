using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnerScript : MonoBehaviour {

	public GameObject enemy;
	public float rangeX;
	public float rangeY;
	float randX;
	float randY;
	Vector2 whereToSpawn;
	public int health = 1;
	public float speed = 1.5f;
	public float spawnRate = 2f;
	public float distanceFromPlayers = 2f;
	public float distanceFromBoosts = 1f;
	GameObject[] boosts;
	GameObject[] players;
	GameObject[] enemies;
	private int totalKillCount;
	float nextSpawn = 0.0f;
	int waveAmount;

	// Use this for initialization
	void Start () {	
		this.totalKillCount = 0;
		this.waveAmount = 5;
	}
	
	// Update is called once per frame
	void Update () {
		boosts = GameObject.FindGameObjectsWithTag ("PickUp");
		GameObject player1 = GameObject.FindGameObjectWithTag ("Player");
		GameObject player2 = GameObject.FindGameObjectWithTag ("Player2");

		if (player1 == null && player2 == null) {
			Time.timeScale = 0; // Pause game
			Text gameOverText = GameObject.Find ("GameOverText").GetComponent<Text> ();
			gameOverText.enabled = true;	
		
		} else {

			totalKillCount = 0;
			totalKillCount += player1.GetComponent<RobotController> ().killCount;
			totalKillCount += player2.GetComponent<RobotController> ().killCount;

			if (totalKillCount > 0) {
				if (totalKillCount % this.waveAmount == 0) {
					waveAmount += 5;
					health += 1;
					if (speed <= 4f) {
						speed += 0.5f;
					}
					spawnRate -= 0.5f;
				}
			}

			if (Time.time > nextSpawn) {
				nextSpawn = Time.time + spawnRate;
				randX = Random.Range (-rangeX, rangeX);
				randY = Random.Range (-rangeY, rangeY);
				whereToSpawn = new Vector2 (randX, randY);

				bool canSpawn = true;

				if (Vector2.Distance (whereToSpawn, player1.transform.position) < distanceFromPlayers) {
					canSpawn = false;
				} 

				if (Vector2.Distance (whereToSpawn, player2.transform.position) < distanceFromPlayers) {
					canSpawn = false;
				} 
					

//				foreach (GameObject player in players) {
//					// Ensure enemy is spawned far enough away from player
//					if (Vector2.Distance (whereToSpawn, player.transform.position) < distanceFromPlayers) {
//						canSpawn = false;
//					}
//				}

				// Ensure enemy is spawned far away but closer to boosts
				foreach (GameObject boost in boosts) {
					if (Vector2.Distance (whereToSpawn, boost.transform.position) < distanceFromBoosts) {
						canSpawn = false;
					}
				}

				if (canSpawn) {
					Instantiate (enemy, whereToSpawn, Quaternion.identity);
				}
			}
		
		}

//		if (players.Length == 0) {
//			Time.timeScale = 0; // Pause game
//			Text gameOverText = GameObject.Find ("GameOverText").GetComponent<Text> ();
//			gameOverText.enabled = true;	
//		}


	}
}
