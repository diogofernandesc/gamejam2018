using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

	public int totalScore = 0;
	public static GameController instance = null;
	private RobotController robot;
	private SpriteRenderer healthBarSprite;

	public Sprite fiveHealth;
	public Sprite fourHealth;
	public Sprite threeHealth;
	public Sprite twoHealth;
	public Sprite oneHealth;

	private Text scoreText;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if(instance != this){
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	public void UpdateHealthBarSprite(){
		robot = GameObject.Find ("Robot").GetComponent<RobotController> ();
		healthBarSprite = GameObject.Find ("HealthBar").GetComponent<SpriteRenderer> ();

		switch (robot.health) {
		case 5:
			healthBarSprite.sprite = fiveHealth;
			break;
		case 4:
			healthBarSprite.sprite = fourHealth;
			break;
		case 3:
			healthBarSprite.sprite = threeHealth;
			break;
		case 2:
			healthBarSprite.sprite = twoHealth;
			break;
		case 1:
			healthBarSprite.sprite = oneHealth;
			break;
		}
	}

	public void updateScore(int score){
		totalScore += 1;

		Text ScoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		ScoreText.text = "Score: " + totalScore;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
