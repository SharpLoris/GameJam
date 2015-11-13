using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed;
	CharacterController controller;

	const float gravity = 9.8f;
	const float jumpSpeed = 3;
	private float vSpeed = 0; //Vertical speed


	// Use this for initialization
	void Start () {
		controller = this.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		//Calculate Velocity
		Vector3 velocity = transform.right * Input.GetAxis ("Horizontal") * speed;
		//Gravity and Jumping
		if (controller.isGrounded) {
			vSpeed = 0;
		
			if (Input.GetAxis ("Jump") == 1) {
				vSpeed = jumpSpeed;
				Debug.Log ("JUMP");
			}
		}
		vSpeed -= gravity * Time.deltaTime;
		velocity.y = vSpeed;
		//Move Player
		controller.Move (velocity * Time.deltaTime);


	}
}
