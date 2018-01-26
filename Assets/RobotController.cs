using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Triggered at these brackets
public class RobotController : MonoBehaviour {

	public Rigidbody2D rb2d;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 mov = new Vector2(this.speed * Input.GetAxis ("Horizontal"), this.speed * Input.GetAxis ("Vertical"));
		this.rb2d.velocity = mov;
	}
}
