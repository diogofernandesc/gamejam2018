using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlled : MonoBehaviour {
	public int playerID;
	private string FIRE_1_KEY;
	private string FIRE_2_KEY;
	private string LOOK_H_KEY;
	private string LOOK_V_KEY;
	private string MOVE_H_KEY;
	private string MOVE_V_KEY;
	private string FIRE_1_JOY;
	private string FIRE_1_JOY_MAC;
	private string FIRE_2_JOY;
	private string FIRE_2_JOY_MAC;
	private string LOOK_H_JOY;
	private string LOOK_H_JOY_MAC;
	private string LOOK_V_JOY;
	private string LOOK_V_JOY_MAC;
	private string MOVE_H_JOY;
	private string MOVE_V_JOY;
	private bool isMac;

	// Use this for initialization
	void Start () {
		this.isMac = Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer;
		FIRE_1_KEY = "pc " + playerID + " fire 1";
		FIRE_2_KEY = "pc " + playerID + " fire 2";
		LOOK_H_KEY = "pc " + playerID + " look h";
		LOOK_V_KEY = "pc " + playerID + " look v";
		MOVE_H_KEY = "pc " + playerID + " move h";
		MOVE_V_KEY = "pc " + playerID + " move v";
		FIRE_1_JOY = "joystick " + playerID + " fire 1";
		FIRE_1_JOY_MAC = "joystick " + playerID + " fire 1 mac";
		FIRE_2_JOY = "joystick " + playerID + " fire 2";
		FIRE_2_JOY_MAC = "joystick " + playerID + " fire 2 mac";
		LOOK_H_JOY = "joystick " + playerID + " look h";
		LOOK_H_JOY_MAC = "joystick " + playerID + " look h mac";
		LOOK_V_JOY = "joystick " + playerID + " look v";
		LOOK_V_JOY_MAC = "joystick " + playerID + " look v mac";
		MOVE_H_JOY = "joystick " + playerID + " move h";
		MOVE_V_JOY = "joystick " + playerID + " move v";
	}

	public bool isFiring1() {
		float joyAxis = this.isMac ? Input.GetAxis (FIRE_1_JOY_MAC) : Input.GetAxis (FIRE_1_JOY);
		return Input.GetAxis (FIRE_1_KEY) != 0f || joyAxis != 0f;
	}

	public bool isFiring2() {
		float joyAxis = this.isMac ? Input.GetAxis (FIRE_2_JOY_MAC) : Input.GetAxis (FIRE_2_JOY);
		return Input.GetAxis (FIRE_2_KEY) != 0f || joyAxis != 0f;
	}

	public float getHLook() {
		float lookKeyAxis = Input.GetAxis (LOOK_H_KEY);
		if (lookKeyAxis == 0f) {
			return this.isMac ? Input.GetAxis(LOOK_H_JOY_MAC) : Input.GetAxis (LOOK_H_JOY);
		}
		return lookKeyAxis;
	}

	public float getVLook() {
		float lookKeyAxis = Input.GetAxis (LOOK_V_KEY);
		if (lookKeyAxis == 0f) {
			return this.isMac ? Input.GetAxis(LOOK_V_JOY_MAC) : Input.GetAxis (LOOK_V_JOY);
		}
		return lookKeyAxis;
	}

	public float getHMove() {
		if (Input.GetAxis (MOVE_H_KEY) == 0f) {
			return Input.GetAxis (MOVE_H_JOY);
		}
		return Input.GetAxis (MOVE_H_KEY);
	}

	public float getVMove() {
		if (Input.GetAxis (MOVE_V_KEY) == 0f) {
			return Input.GetAxis (MOVE_V_JOY);
		}
		return Input.GetAxis (MOVE_V_KEY);
	}
}
