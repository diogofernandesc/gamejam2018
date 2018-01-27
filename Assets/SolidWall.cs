using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidWall : Collider2D {
	void OnTriggerEnter(Collider2D c2d) {
		GameObject collidingObject = c2d.gameObject;
		if (collidingObject.GetComponent<Bullet>() != null) {
			Destroy (collidingObject);
		}
	}
}
