using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
		public float speed;
		public float jumpSpeed;
		private float groundHeight;

		void Start ()
		{
				this.groundHeight = this.transform.position.y;
		}

		void FixedUpdate ()
		{
				//these are the requirements required to jump
				//if the space key is pressed, while the player object is on the ground, allow jump
				if (Input.GetKeyDown ("space") && (this.transform.position.y <= this.groundHeight)) {
						this.Jump ();
				} else {
						float moveHorizontal = Input.GetAxis ("Horizontal");
						float moveVertical = Input.GetAxis ("Vertical");
		
						Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
						this.rigidbody.AddForce (movement * this.speed * Time.deltaTime);
				}
		}

		//adds a force to the y value equal to the jump speed
		void Jump ()
		{
				this.rigidbody.AddForce (Vector3.up * this.jumpSpeed);

		}
}