using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour
{

		public GameObject prefab;
		private float limitForHowLongToMove = 2;
		private float counterOfTimePassed;
		private int health;
		private int numSpawns;
		const int MAX_SPAWNS = 7;

		// Use this for initialization
		void Start ()
		{
				this.health = 1000;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (health <= 0) {
						Destroy (this.gameObject);
				}
		}

		void FixedUpdate ()
		{
				this.counterOfTimePassed += Time.deltaTime;

				if (this.counterOfTimePassed > this.limitForHowLongToMove) {
						if (this.numSpawns < MAX_SPAWNS) {
								this.newSpawn ();
						}
						this.counterOfTimePassed = 0;
				} 
		}

		public void spawnDied ()
		{
				this.numSpawns--;
		}

		private void newSpawn ()
		{
				GameObject clone = Instantiate (prefab, this.transform.position, Quaternion.identity) as GameObject;
				clone.GetComponent<EnemyController> ().setSpawner (this.gameObject);
				this.numSpawns++;
		}

		void OnTriggerEnter (Collider other)
		{
				if (other.gameObject.tag.Equals ("Bullet")) {
						health--;
						this.gameObject.renderer.material.color = new Color ((this.gameObject.renderer.material.color.r + 0.001f),
			                                                     this.gameObject.renderer.material.color.g,
			                                                     this.gameObject.renderer.material.color.b);
				}
		}
}
