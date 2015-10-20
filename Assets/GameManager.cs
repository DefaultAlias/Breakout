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
		// set the initial values for the UI
		ballCountText.text = "Balls: " + ballCount;
		scoreText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void BallShouldDie(){
		// check if we still have balls to spare
		if(ballCount > 0){
			// decrement the ball count
			ballCount -= 1;

			// reset the ball state and position
			ball.Reset();

			// set the UI text
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
		// increment the score
		score += hitScore;

		// set the UI text
		scoreText.text = "Score: " + score;

		// I know beforehand that the max score is 70
		if(score >= 70){
			// set the gameover panel to be active so it will display
			gameoverPanel.SetActive(true);
		}
	}

	public void RestartGame(){
		// this is really as simple as just reloading the level
		Application.LoadLevel("mainScene");
	}
}
