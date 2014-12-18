using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
		private int speed = 5;
		public GameObject prefab;
		int direction;
		bool fired;
		bool[] wallsInDirection = new bool[4];
		private float delayBetweenFirings = 1;
		private float counterOfTimePassed;
		private float health;

		// Use this for initialization
		void Start ()
		{
				this.counterOfTimePassed = 0;
		this.health = 100;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKey ("up") 
						|| Input.GetKey ("right") 
						|| Input.GetKey ("down") 
						|| Input.GetKey ("left")) {
						if (Input.GetKey ("up")) {
								direction = 0;
						} else if (Input.GetKey ("right")) {
								direction = 1;
						} else if (Input.GetKey ("down")) {
								direction = 2;
						} else if (Input.GetKey ("left")) {
								direction = 3;
						}
						this.move ();
				}

				if (Input.GetKey ("w")) {
						this.fire (0);
				} else if (Input.GetKey ("a")) {
						this.fire (3);
				} else if (Input.GetKey ("s")) {
						this.fire (2);
				} else if (Input.GetKey ("d")) {
						this.fire (1);
				}
		}

		private void fire (int direction)
		{
				if (!this.fired) {
						GameObject clone;
						clone = Instantiate (prefab, this.transform.position, Quaternion.identity) as GameObject;
						clone.GetComponent<BulletController> ().setDirection (direction);
						this.fired = true;
				}
		}

		void FixedUpdate ()
		{
				if (this.fired) {
						this.counterOfTimePassed += Time.deltaTime;
				
						if (this.counterOfTimePassed > this.delayBetweenFirings) {
								this.fired = false;
								this.counterOfTimePassed = 0;
						} 
				}
		}

		public int getDirection ()
		{
				return direction;
		}

		void OnTriggerEnter (Collider other)
		{
				if (other.gameObject.tag.Equals ("Door")) {

				} else if (other.gameObject.tag.Equals ("Wall")) {
						this.wallsInDirection [this.direction] = true;
				}
		}

		private void move ()
		{
				if (!wallsInDirection [this.direction]) {
						Vector3 move = new Vector3 (0f, 0f, 0f);

						switch (this.direction) {
						case 0:
								move = new Vector3 (0f, 0f, 1f);
								break;
						case 1:
								move = new Vector3 (1f, 0f, 0f);
								break;
						case 2:
								move = new Vector3 (0f, 0f, -1f);
								break;
						case 3:
								move = new Vector3 (-1f, 0f, 0f);
								break;
						default:
								move = new Vector3 (0f, 0f, 0f);
								break;
						}

						this.wallsInDirection [(this.direction + 2) % 4] = false;
						this.gameObject.transform.Translate (move * Time.deltaTime * this.speed);
				}
		}
}
