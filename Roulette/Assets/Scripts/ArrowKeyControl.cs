using UnityEngine;
using System.Collections;

public class ArrowKeyControl : MonoBehaviour {
	public float speed;

	//push the ball on the world x-z plane with the arrow keys
	void FixedUpdate() {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}
}
