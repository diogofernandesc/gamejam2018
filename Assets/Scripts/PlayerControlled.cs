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
	private string FIRE_1_JOY_MAC;
	private string FIRE_2_JOY;
	private string FIRE_2_JOY_MAC;
	private string TURN_JOY;
	private string TURN_JOY_MAC;
	private string MOVE_JOY;
	private bool isMac;

	// Use this for initialization
	void Start () {
		this.isMac = Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer;
		FIRE_1_JOY = "joystick " + playerID + " fire 1";
		FIRE_1_JOY_MAC = "joystick " + playerID + " fire 1 mac";
		FIRE_2_JOY = "joystick " + playerID + " fire 2";
		FIRE_2_JOY_MAC = "joystick " + playerID + " fire 2 mac";
		TURN_JOY = "joystick " + playerID + " turn";
		TURN_JOY_MAC = "joystick " + playerID + " turn mac";
		MOVE_JOY = "joystick " + playerID + " move";
		FIRE_1_KEY = "pc " + playerID + " fire 1";
		FIRE_2_KEY = "pc " + playerID + " fire 2";
		TURN_KEY = "pc " + playerID + " turn";
		MOVE_KEY = "pc " + playerID + " move";
	}

	public bool isFiring1() {
		float joyAxis = this.isMac ? Input.GetAxis (FIRE_1_JOY_MAC) : Input.GetAxis (FIRE_1_JOY);
		return Input.GetAxis (FIRE_1_KEY) != 0f || joyAxis != 0f;
	}

	public bool isFiring2() {
		float joyAxis = this.isMac ? Input.GetAxis (FIRE_2_JOY_MAC) : Input.GetAxis (FIRE_2_JOY);
		return Input.GetAxis (FIRE_2_KEY) != 0f || joyAxis != 0f;
	}

	public float turnAmount() {
		float turnKeyAxis = Input.GetAxis (TURN_KEY);
		if (turnKeyAxis == 0f) {
			return this.isMac ? Input.GetAxis(TURN_JOY_MAC) : Input.GetAxis (TURN_JOY);
		}
		return turnKeyAxis;
	}

	public float moveAmount() {
		if (Input.GetAxis (MOVE_KEY) == 0f) {
			return Input.GetAxis (MOVE_JOY);
		}
		return Input.GetAxis (MOVE_KEY);
	}
}
