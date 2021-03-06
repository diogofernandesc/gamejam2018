﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour 
{
	public float max_cooldown;
	public float cooldown;
	public Bullet meanBullet;
	public Bullet niceBullet;
	public float bulletOffset;
	public PlayerControlled pc;
	public GameObject baseObject;

	// Use this for initialization
	void Start () {
		this.cooldown = 0.0f;
		this.max_cooldown = 1.0f;
		this.bulletOffset = 1.2f;
	}
	
	// Update is called once per frame
	// Get angle from horizontal and vertical axes
	// tan(theta) = Opp / AdjW
	// theta = atan2(Opp / Adj)
	void Update() {
		float zangle = Mathf.Rad2Deg * Mathf.Atan2(this.pc.getVLook(), this.pc.getHLook());
		this.gameObject.transform.Rotate(new Vector3(0f, 0f, zangle - this.gameObject.transform.eulerAngles.z));
	}

	void FixedUpdate () {
		if (this.cooldown > 0.0f) {
			this.cooldown -= 0.1f;
		}
		if (this.pc.isFiring1()) {
			if (this.cooldown <= 0.0f) {
				Instantiate (meanBullet, this.offsetPositionUsingRotation(), this.gameObject.transform.rotation);
				meanBullet.setShooter (this.baseObject);
				this.cooldown = this.max_cooldown;
			}
		}
		else if (this.pc.isFiring2()) {
			if (this.cooldown <= 0.0f) {
				Instantiate (niceBullet, this.offsetPositionUsingRotation(), this.gameObject.transform.rotation);
				niceBullet.setShooter (this.baseObject);
				this.cooldown = this.max_cooldown;
			}
		}
	}

	Vector2 offsetPositionUsingRotation ()
	{
		Vector2 offsetPos = this.gameObject.transform.position;
		float x = offsetPos.x;
		float y = offsetPos.y;
		float zangle = this.gameObject.transform.eulerAngles.z * Mathf.Deg2Rad;
		offsetPos.Set (x + bulletOffset * Mathf.Cos(zangle), y + bulletOffset * Mathf.Sin(zangle));
		return offsetPos;
	}
}
