using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{

		Vector3 movement;
		private int speed = 20;
		float lifeSpan = 1.0f;
		float timeAlive;

		// Use this for initialization
		void Start ()
		{
				this.transform.parent = GameObject.FindGameObjectWithTag ("DynamicObjects").transform;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void FixedUpdate ()
		{
				this.transform.Translate (movement * Time.deltaTime * speed);
				this.timeAlive += Time.deltaTime;

				if (timeAlive > lifeSpan) {
						Destroy (this);
				}
		}

		public void setDirection (int direction)
		{

				switch (direction) {
				case 0:
						movement = Vector3.forward;
						break;
				case 1: 
						movement = Vector3.right;
						break;
				case 2:
						movement = Vector3.back;
						break;
				case 3:
						movement = Vector3.left;
						break;
				}
		}

		void OnTriggerEnter (Collider other)
		{
				if (!other.gameObject.tag.Equals ("Player") && !other.gameObject.tag.Equals ("Floor")) {
						Destroy (this.gameObject);
				}
		}
}
