using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlled : MonoBehaviour {
	public int playerID;
	private string FIRE_1_KEY;
	private string FIRE_2_KEY;
	private string TURN_KEY;
	private string MOVE_KEY;
	private string FIRE_1_JOY;
	private string FIRE_2_JOY;
	private string TURN_JOY;
	private string MOVE_JOY;
	// Use this for initialization
	void Start () {
		FIRE_1_JOY = "joystick " + playerID + " fire 1";
		FIRE_2_JOY = "joystick " + playerID + " fire 2";
		TURN_JOY = "joystick " + playerID + " turn";
		MOVE_JOY = "joystick " + playerID + " move";
		FIRE_1_KEY = "pc " + playerID + " fire 1";
		FIRE_2_KEY = "pc " + playerID + " fire 2";
		TURN_KEY = "pc " + playerID + " turn";
		MOVE_KEY = "pc " + playerID + " move";
	}

	public bool isFiring1() {
		return Input.GetAxis (FIRE_1_KEY) != 0f || Input.GetAxis(FIRE_1_JOY) != 0f;
	}

	public bool isFiring2() {
		return Input.GetAxis (FIRE_2_KEY) != 0f || Input.GetAxis(FIRE_2_JOY) != 0f;
	}

	public float turnAmount() {
		if (Input.GetAxis (TURN_KEY) == 0f) {
			return Input.GetAxis (TURN_JOY);
		}
		return Input.GetAxis (TURN_KEY);
	}

	public float moveAmount() {
		if (Input.GetAxis (MOVE_KEY) == 0f) {
			return Input.GetAxis (MOVE_JOY);
		}
		return Input.GetAxis (MOVE_KEY);
	}
}
