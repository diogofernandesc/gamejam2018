using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawnerScript : MonoBehaviour {

	public float distanceFromOtherBoosts = 3f;
	public float distanceFromPlayer = 2f;
	public float distanceFromEnemies = 2f;
	public float rangeX;
	public float rangeY;
	public GameObject boost;
	float randX;
	float randY;
	Vector2 whereToSpawn;
	public float spawnRate = 2f;
	public GameObject[] boosts;
	public GameObject[] enemies;
	public GameObject[] players;
	float nextSpawn = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {

		boosts = GameObject.FindGameObjectsWithTag ("PickUp");
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		GameObject player1 = GameObject.FindGameObjectWithTag ("Player");
		GameObject player2 = GameObject.FindGameObjectWithTag ("Player2");

		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			randX = Random.Range (-rangeX, rangeX);
			randY = Random.Range (-rangeY, rangeY);
			whereToSpawn = new Vector2 (randX, randY);

			bool canSpawn = true;

			if (player1 != null) {
				if (Vector2.Distance (whereToSpawn, player1.transform.position) < distanceFromPlayer) {
					canSpawn = false;	

				}
			}

			if (player2 != null) {
				if (Vector2.Distance (whereToSpawn, player2.transform.position) < distanceFromPlayer) {
					canSpawn = false;	

				}
			}
				

			// Ensure boost is spawned far away but close enough to enemies
			foreach (GameObject enemy in enemies) {
				if (Vector2.Distance (whereToSpawn, boost.transform.position) < distanceFromOtherBoosts) {
					canSpawn = false;
				}
			}
				
			// Ensure boost is spawned far away enough from other boosts
			foreach (GameObject boost in boosts) {
				if (Vector2.Distance (whereToSpawn, boost.transform.position) < distanceFromOtherBoosts) {
					canSpawn = false;
				}
			}

			if (canSpawn) {
				if (player1 != null || player2 != null) {
					Instantiate (boost, whereToSpawn, Quaternion.identity);
				}
			}
		}
	}
}
