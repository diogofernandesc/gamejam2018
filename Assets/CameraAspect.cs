using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspect : MonoBehaviour {

	public GameObject background;

	// Use this for initialization
	void Start () {
		Vector3 xyz = background.GetComponent<Renderer>().bounds.size;

		print (xyz);
		float distance = Mathf.Max(xyz.x, xyz.y, xyz.z);
		distance /= (2.0f * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad));
		// Move camera in -z-direction; change '2.0f' to your needs
		Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -distance * 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
