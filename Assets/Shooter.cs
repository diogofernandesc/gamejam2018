using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour 
{
	public float max_cooldown;
	public float cooldown;
	public Bullet bullet;

	// Use this for initialization
	void Start () {
		this.cooldown = 0.0f;
		this.max_cooldown = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.cooldown > 0.0f) {
			this.cooldown -= 0.1f;
		}
		if (Input.GetKeyDown ("space")) {
			if (this.cooldown <= 0.0f) {
				Instantiate (bullet, this.transform);
				this.cooldown = this.max_cooldown;
			}
		}
	}
}
