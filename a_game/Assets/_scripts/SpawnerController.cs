using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour {

	public GameObject prefab;
	private float limitForHowLongToMove = 2;
	private float counterOfTimePassed;
	private int health;

	// Use this for initialization
	void Start () {
		this.health = 1000;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Destroy(this.gameObject);
		}
	}

	void FixedUpdate() {
		this.counterOfTimePassed += Time.deltaTime;

		if (this.counterOfTimePassed > this.limitForHowLongToMove) {
			this.newSpawn ();
			this.counterOfTimePassed = 0;
		} 
	}

	private void newSpawn() {
		Instantiate(prefab, this.transform.position, Quaternion.identity);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Bullet")){
		    health--;
			this.gameObject.renderer.material.color = new Color ((this.gameObject.renderer.material.color.r + 0.001f),
			                                                     this.gameObject.renderer.material.color.g,
			                                                     this.gameObject.renderer.material.color.b);
		}
	}
}
