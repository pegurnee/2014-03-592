using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour
{
	
	
		Vector3 movement;
		private int speed = 8;
		float lifeSpan = 1.0f;
		float timeAlive;

		// Use this for initialization
		void Start ()
		{
				this.transform.parent = GameObject.FindGameObjectWithTag ("DynamicObjects").transform;
	
		}
	
		void FixedUpdate ()
		{
				this.transform.Translate (movement * Time.deltaTime * speed);
				this.timeAlive += Time.deltaTime;
		
				if (timeAlive > lifeSpan) {
						Destroy (this);
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnTriggerEnter (Collider other)
		{
				if (!other.gameObject.tag.Equals ("Floor") && !other.gameObject.tag.Equals("Boss")) {
						Destroy (this.gameObject);
				}
		}

		public void setMovement (Vector3 movement)
		{
				this.movement = movement;
		}
}
