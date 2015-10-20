using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float movementSpeed = 0.25f;
	public float maxDist = 5.0f;

	private Rigidbody body;

	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// check to make sure paddle is not out of range
		if(this.transform.position.x > maxDist){
			this.transform.position = new Vector3(maxDist, this.transform.position.y, this.transform.position.z);
		}
		else if(this.transform.position.x < -maxDist){	
			this.transform.position = new Vector3(-maxDist, this.transform.position.y, this.transform.position.z);
		}
	}

	void FixedUpdate () {
		// respond to user input and move the paddle
		float move = Input.GetAxis("Horizontal");
		this.transform.position = this.transform.position + new Vector3(movementSpeed * move, 0, 0);

	}
}
