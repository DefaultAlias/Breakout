using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Text ballCountText;
	public Text scoreText;
	public GameObject gameoverPanel;
	public Ball ball;

	private int ballCount = 3;
	private int score = 0;
	// Use this for initialization
	void Start () {
		ballCountText.text = "Balls: " + ballCount;
		scoreText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void BallShouldDie(){
		if(ballCount > 0){
			ballCount -= 1;
			ball.Reset();
			ballCountText.text = "Balls: " + ballCount;
		}
		else{
			// game over man
			// we set the gameover panel to be active at this 
			// point so that it becomes visible
			gameoverPanel.SetActive(true);
		}
	}

	public void BlockHit(int hitScore){
		score += hitScore;
		scoreText.text = "Score: " + score;
		if(score >= 70){
			gameoverPanel.SetActive(true);
		}
	}

	public void RestartGame(){
		// this is really as simple as just reloading the level
		Application.LoadLevel("mainScene");
	}
}
