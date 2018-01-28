using System.Collections;
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

	// Use this for initialization
	void Start () {
		this.cooldown = 0.0f;
		this.max_cooldown = 1.0f;
		this.bulletOffset = 0.4f;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.cooldown > 0.0f) {
			this.cooldown -= 0.1f;
		}
		if (pc.isFiring1()) {
			if (this.cooldown <= 0.0f) {
				Instantiate (meanBullet, this.offsetPositionUsingRotation(), this.gameObject.transform.rotation);
				meanBullet.setShooter (this.gameObject);
				this.cooldown = this.max_cooldown;
			}
		}
		else if (pc.isFiring2()) {
			if (this.cooldown <= 0.0f) {
				Instantiate (niceBullet, this.offsetPositionUsingRotation(), this.gameObject.transform.rotation);
				niceBullet.setShooter (this.gameObject);
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
