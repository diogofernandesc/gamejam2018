using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	public Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		this.speed = 3;
		float zangle = this.transform.eulerAngles.z;
		rb2d.velocity = new Vector2 (this.speed * Mathf.Cos(zangle), this.speed * Mathf.Sin(zangle));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter() {
		print ("LOL COLLIDED");
	}
}
