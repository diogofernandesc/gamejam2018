using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	public Rigidbody2D rb2d;

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
}
