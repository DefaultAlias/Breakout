using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int numHits = 1;

	private Renderer renderer;

	// Use this for initialization
	void Start () {
		// get the renderer component, we'll use this to 
		// modify the materials later
		renderer = gameObject.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		// the brick color is dependent on the number of hits left
		// in the numHits counter. we use a simple switch case to
		// go through the colors. You could use a formula for this
		// as well, but i chose to explicitly define which colors 
		// correlate to the points left
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

		if(damage > numHits){
			// damage would be greater than the points left on the 
			// block, so we assign the hits left as the score
			score = numHits;
		}
		else{
			// brick has more hits left than damage being dealt, so
			// we assign the damage dealt to the score
			score = damage;
		}

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
