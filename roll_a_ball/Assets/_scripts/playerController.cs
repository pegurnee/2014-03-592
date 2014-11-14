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
				if (Input.GetKeyDown ("space") 
						&& (this.transform.position.y <= this.groundHeight)
		    ) {
						this.rigidbody.AddForce (Vector3.up * this.jumpSpeed);
				} else {
						float moveHorizontal = Input.GetAxis ("Horizontal");
						float moveVertical = Input.GetAxis ("Vertical");
		
						Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
						this.rigidbody.AddForce (movement * this.speed * Time.deltaTime);
				}
		}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Pickup")
		{
			other.gameObject.SetActive(false);
		}
	}
}