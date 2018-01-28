using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {

	public GameObject enemy;
	public float rangeX;
	public float rangeY;
	float randX;
	float randY;
	Vector2 whereToSpawn;
	public float spawnRate = 2f;
	public float distanceFromPlayers = 2f;
	public float distanceFromBoosts = 1f;
	GameObject[] boosts;
	GameObject[] players;

	float nextSpawn = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		boosts = GameObject.FindGameObjectsWithTag ("PickUp");
		players = GameObject.FindGameObjectsWithTag ("Player");

		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			randX = Random.Range (-rangeX, rangeX);
			randY = Random.Range (-rangeY, rangeY);
			whereToSpawn = new Vector2 (randX, randY);

			bool canSpawn = true;


			foreach (GameObject player in players) {
				// Ensure enemy is spawned far enough away from player
				if (Vector2.Distance (whereToSpawn, player.transform.position) < distanceFromPlayers) {
					canSpawn = false;
				}
			}
				
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
}
