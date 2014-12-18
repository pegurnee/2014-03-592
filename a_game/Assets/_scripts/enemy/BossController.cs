using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{

		public GameObject player;
		public GameObject missile;
		int moveSpeed = 3;
		int maxDist = 10;
		int minDist = 4;
		int health;
		bool canShoot;
		private float delayBetweenFirings = 2;
		private float counterOfTimePassed;

	
		// Use this for initialization
		void Start ()
		{
				this.player = GameObject.FindGameObjectWithTag ("Player");
				this.health = 5;
				this.canShoot = false;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (this.canShoot) {
						this.transform.LookAt (player.transform);
						if (Vector3.Distance (transform.position, player.transform.position) >= minDist) {
			
								transform.position += transform.forward * moveSpeed * Time.deltaTime;

								if (Vector3.Distance (transform.position, player.transform.position) <= minDist) {
										//Here Call any function U want Like Shoot at here or something
										this.shoot ();
										this.gameObject.renderer.material.color = Color.black;
								} 
			
						}
				}
		}

		void FixedUpdate ()
		{
				if (!this.canShoot) {
						this.counterOfTimePassed += Time.deltaTime;
						this.transform.Rotate (new Vector3 (0, 45, 0) * Time.deltaTime);
						this.gameObject.renderer.material.color = new Color ((this.gameObject.renderer.material.color.r + 0.01f), 
			                                                    this.gameObject.renderer.material.color.g + 0.01f,
			                                                    this.gameObject.renderer.material.color.b);
						if (this.counterOfTimePassed > this.delayBetweenFirings) {
								this.canShoot = true;
								this.counterOfTimePassed = 0;
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

		void shoot ()
		{
		Debug.Log ("boom!");
				this.canShoot = false;
		}
}
