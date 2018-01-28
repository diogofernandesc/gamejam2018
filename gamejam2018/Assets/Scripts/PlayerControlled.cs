using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlled : MonoBehaviour {
	public int playerID;
	private string FIRE_1;
	private string FIRE_2;
	private string TURN;
	private string MOVE;
	// Use this for initialization
	void Start () {
		FIRE_1 = "joystick " + playerID + " fire 1";
		FIRE_2 = "joystick " + playerID + " fire 2";
		TURN = "joystick " + playerID + " turn";
		MOVE = "joystick " + playerID + " move";
	}

	public bool isFiring1() {
		return Input.GetAxis (FIRE_1) != 0f;
	}

	public bool isFiring2() {
		return Input.GetAxis (FIRE_2) != 0f;
	}

	public float turnAmount() {
		return Input.GetAxis (TURN);
	}

	public float moveAmount() {
		return -Input.GetAxis (MOVE);
	}
}
