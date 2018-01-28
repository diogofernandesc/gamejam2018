 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	private Vector3 velocity = Vector3.zero;
	private Vector3 offset2;
	public GameObject player2;
	private bool deadFirstTime = false;

	// Use this for initialization
	void Start () {
		var test = new Vector3(17/10,0,0);
			offset = transform.position - player.transform.position + test;

			offset2 = transform.position - player2.transform.position + test;

	
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
		if (player != null) {
			transform.position = player.transform.position + offset;
		} else {
			if (!deadFirstTime) {
				transform.position = Vector3.SmoothDamp(transform.position, (player2.transform.position + offset2), ref velocity, 4F);
				deadFirstTime = true;
			} else {
				transform.position = player2.transform.position + offset2;
			}
		///if (transform.position.x > -6.4 || player.transform.position.x > -5) {
		}
		//}
	}
}
