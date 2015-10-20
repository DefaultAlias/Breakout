using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Ball : MonoBehaviour {
	public float maxSpeed = 10.0f;
	public Vector3 customGravity = new Vector3(0, 0.25f, 0);

	private Rigidbody body;
	private bool isInPlay = false;

	// Use this for initialization
	void Start () {
		// get the rigidbody for use later in the code
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// call the serve method when user presses Jump button (mapped to space by default)
		if(Input.GetAxis("Jump") > 0){
			Serve();
		}
	}

	// Fixed update is called at a fixed rate
	void FixedUpdate(){
		if(isInPlay){
			// a constant force is applied while ball is in motion
			// so that it can't get stuck bouncing horizontally 
			// for too long.
			body.AddForce(customGravity);

			// A little about vectors:
			// Vectors are not just points in space. In this instance, we're using
			// then to represent direction. Something you may not realize though, is
			// a vector can also have a length. consider (2,2,2), 
			// it's length (sqrt(2*2 + 2*2 + 2*2) is 3.46..
			//
			// This is useful because a vector can simultaneously represent the 
			// direction and speed an entity is moving.
			//
			// When a vector is normalized, it's components are scaled proportionaly
			// so that all of the ratios between components remain while the length
			// of the vector becomes exactly 1.
			//
			// With a length, also known as magnitude, of 1, we can assume the vector
			// is describing only the direction. We can then multiply this vector by a 
			// scalar value to get another vector that has the same direction, but
			// a magnitude equal to that scalar!
			body.velocity = Vector3.Normalize(body.velocity) * maxSpeed;
		}
	}

	void OnCollisionEnter(Collision collision){
		// here we're using tags to figure out if we've hit the killbox
		if(collision.gameObject.tag == "Killbox"){
			// this is a weird bit, but we're sending a message to the parent of this 
			// game object (scene), which will call any methods called "BallShouldDie"
			transform.parent.gameObject.BroadcastMessage("BallShouldDie");
		}
	}

	public void Reset(){
		// simply reset everything to the initial state
		body.velocity = Vector3.zero;
		body.position = Vector3.zero;
		isInPlay = false;
	}

	public void Serve(){
		// check if the ball is in play
		if(!isInPlay){
			// set the ball into motion
			body.velocity = new Vector3(0, -maxSpeed, 0);

			// make sure this can't get called again until the ball is out of play
			isInPlay = true;
		}
	}
}
