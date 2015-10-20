using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int numHits = 1;

	private Renderer renderer;

	// Use this for initialization
	void Start () {

		renderer = gameObject.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		switch(numHits){
			case 1:  renderer.material.color = Color.red;    break;
			case 2:  renderer.material.color = Color.yellow; break;
			case 3:  renderer.material.color = Color.green;  break;
			case 4:  renderer.material.color = Color.blue;   break;
			default: renderer.material.color = Color.red;    break;
		}
	}

	void GetHit(int damage){
		int score = 0;
		// prevent adding points for overkill
		if(damage > numHits)
			score = numHits;
		else
			score = damage;

		// subtract points
		numHits -= damage;

		// tell everyone we got hit and how hard
		transform.parent.parent.gameObject.BroadcastMessage("BlockHit", score);

		// destroy if we're dead
		if(numHits <= 0){
			GameObject.Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "Ball"){
			GetHit(1);
		}
	}
}
