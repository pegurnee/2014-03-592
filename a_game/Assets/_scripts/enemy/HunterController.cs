using UnityEngine;
using System.Collections;

public class HunterController : MonoBehaviour
{

		public GameObject player;
		int moveSpeed = 2;
		int maxDist = 10;
		int minDist = 0;
		int health;

		// Use this for initialization
		void Start ()
		{
				this.player = GameObject.FindGameObjectWithTag ("Player");
				this.health = 3;
		}
	
		// Update is called once per frame
		void Update ()
		{
				this.transform.LookAt (player.transform);
				if (Vector3.Distance (transform.position, player.transform.position) >= minDist) {
			
						transform.position += transform.forward * moveSpeed * Time.deltaTime;
			
			
			
						if (Vector3.Distance (transform.position, player.transform.position) <= maxDist) {
								//Here Call any function U want Like Shoot at here or something
						} 
			
				}
		}

		void OnTriggerEnter (Collider other)
		{
				if (other.gameObject.tag.Equals ("Bullet")) {
						this.health--;
						if (this.health <= 0) {
								Destroy (this.gameObject);
						}
				} else if (other.gameObject.tag.Equals ("Wall")) {
						Destroy (this.gameObject);
				} 
		}
}
