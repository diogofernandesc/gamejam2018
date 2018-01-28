using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {

	public GameObject player;
	public GameObject enemy;
	float randX;
	float randY;
	Vector2 whereToSpawn;
	public float spawnRate = 2f;
	public float distanceFromEnemy = 2f;
	public float distanceFromBoosts = 1f;
	GameObject[] boosts;

	float nextSpawn = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		boosts = GameObject.FindGameObjectsWithTag ("PickUp");

		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			randX = Random.Range (-4.4f, 4.4f);
			randY = Random.Range (-4.4f, 4.4f);
			whereToSpawn = new Vector2 (randX, randY);

			bool canSpawn = true;

			// Ensure enemy is spawned far enough away from player
			if (Vector2.Distance (whereToSpawn, player.transform.position) >= distanceFromEnemy) {

				// Ensure enemy is spawned far away but closer to boosts
				foreach (GameObject boost in boosts) {
					if (Vector2.Distance (whereToSpawn, boost.transform.position) < distanceFromBoosts) {
						canSpawn = false;
					}
				}
			} else {
				canSpawn = false;	
			}

			if (canSpawn) {
				Instantiate (enemy, whereToSpawn, Quaternion.identity);
			}
		}
	}
}
