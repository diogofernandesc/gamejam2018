using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	public Rigidbody2D rb2d;
	public int targetHealthChange;
	public int shooterHealthChange;
	private GameObject shooter;


	// Use this for initialization
	void Start () {
		//The speed the bullet will move at.
		//Try to keep it faster than the speed of the robot, or you'll be able to run into your own bullets.
		this.speed = 8;
		float zangleRad = this.transform.eulerAngles.z * Mathf.Deg2Rad;
		rb2d.velocity = new Vector2 (this.speed * Mathf.Cos(zangleRad), this.speed * Mathf.Sin(zangleRad));
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D c2d) {
		GameObject collidingObject = c2d.gameObject;
		if (collidingObject != this.shooter) {
			if (collidingObject.GetComponent<RobotController> () != null) {
				collidingObject.GetComponent<RobotController> ().health += this.targetHealthChange;
			} else if (collidingObject.GetComponent<EnemyController> () != null) {
				collidingObject.GetComponent<EnemyController> ().health += this.targetHealthChange;
			}
			Destroy (this.gameObject);
		}
	}

	public void setShooter(GameObject shooter) {
		this.shooter = shooter;
		RobotController rc = this.shooter.GetComponent<RobotController>();
		rc.health += this.shooterHealthChange;
	}
}
