using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Rigidbody2D rb2d;
	public int health;
	public GameObject player;
	private float range;
	public float speed = 2f;
	private float minDistance = 1f;

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
		player = GameObject.FindGameObjectWithTag ("Player");
		range = Vector2.Distance(transform.position, player.transform.position);
//		if (range > minDistance) {
//		}
		transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col) {
		
		RobotController rc = col.gameObject.GetComponent<RobotController> ();
		if (rc != null) {
			rc.health -= 1;

		}
	}
}
