using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawnerScript : MonoBehaviour {

	public float distanceFromOtherBoosts = 3f;
	public float distanceFromPlayer = 2f;
	public float distanceFromEnemies = 2f;
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
		players = GameObject.FindGameObjectsWithTag ("Player");

		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			randX = Random.Range (-4.4f, 4.4f);
			randY = Random.Range (-4.4f, 4.4f);
			whereToSpawn = new Vector2 (randX, randY);

			bool canSpawn = true;

			foreach (GameObject player in players) {
				// Ensure boost is spawned far enough away from player
				if (Vector2.Distance (whereToSpawn, player.transform.position) < distanceFromPlayer) {
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
				Instantiate (boost, whereToSpawn, Quaternion.identity);
			}
		}
	}
}
