 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		var test = new Vector3(17/10,0,0);
		offset = transform.position - player.transform.position + test;

		var test2 = new Vector2(17/10,0);

//		print (stones.GetComponent<SpriteRenderer>.bounds.size.x);
		//transform.position = new Vector3
		//	(
		//		Mathf.Clamp (transform.position.x, minimumBoundary.x, maximumBoundary.x),
		//		Mathf.Clamp (transform.position.y, minimumBoundary.y, maximumBoundary.y),
		//		transform.position.z
		//	);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		print (transform.position.x);
		///if (transform.position.x > -6.4 || player.transform.position.x > -5) {
			transform.position = player.transform.position + offset;
		//}
	}
}
