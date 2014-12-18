using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
		private int speed = 5;
		public GameObject prefab;
		public GameController gc;
		int direction;
		bool fired;
		bool[] wallsInDirection = new bool[4];
		private float delayBetweenFirings = 1;
		private float counterOfTimePassed;
		private float health;
		private bool canEnterNewRoom;
		private float tillNewRoom;
		private float newRoomDelay = 3;
		private AudioSource stairs;
		private AudioSource shoot;

		// Use this for initialization
		void Start ()
		{
				this.stairs = GetComponents<AudioSource> () [0];
				this.shoot = GetComponents<AudioSource> () [1];

				this.counterOfTimePassed = 0;
				this.health = 100;
				this.canEnterNewRoom = true;
				healthBarLength = Screen.width * 1 / 2;
		}
	
		// Update is called once per frame
		void Update ()
		{
				AdjustCurrentHealth (0);
				if (this.curHealth <= 0) {
					
				}
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
						this.shoot.Play ();
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
				if (!this.canEnterNewRoom) {
						this.tillNewRoom += Time.deltaTime;
			
						if (this.tillNewRoom > this.newRoomDelay) {
								this.canEnterNewRoom = true;
								this.tillNewRoom = 0;
						} 
				}
		}

		public int getDirection ()
		{
				return direction;
		}

		void OnTriggerEnter (Collider other)
		{
				switch (other.gameObject.tag) {
				case "Door":
						if (this.canEnterNewRoom) {
								this.canEnterNewRoom = false;
								this.gc.createRoom (direction);
								this.stairs.Play ();
						}
						break;
				case "Wall":
						this.wallsInDirection [this.direction] = true;
						break;
				case "Enemy":
						this.health -= 1;
						this.curHealth -= 1;
						break;
				case "Hunter":
						this.health -= 3;
						this.curHealth -= 3;
						break;
				case "Missile":
						this.health -= 10;
						this.curHealth -= 10;
						break;
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

						this.wallsInDirection [(this.direction + 2) % this.wallsInDirection.Length] = false;
						this.gameObject.transform.Translate (move * Time.deltaTime * this.speed);
				}
		}

		public int maxHealth = 100;
		public int curHealth = 100;
		public Texture2D bgImage;
		public Texture2D fgImage;
		public float healthBarLength;
	
		void OnGUI ()
		{
				// Create one Group to contain both images
				// Adjust the first 2 coordinates to place it somewhere else on-screen
				GUI.BeginGroup (new Rect ((Screen.width - this.healthBarLength) / 2, 0, healthBarLength, 32));
		
				// Draw the background image
				GUI.Box (new Rect (0, 0, healthBarLength, 32), bgImage);
		
				// Create a second Group which will be clipped
				// We want to clip the image and not scale it, which is why we need the second Group
				GUI.BeginGroup (new Rect (0, 0, curHealth / maxHealth * healthBarLength, 32));
		
				// Draw the foreground image
				GUI.Box (new Rect (0, 0, healthBarLength, 32), fgImage);
		
				// End both Groups
				GUI.EndGroup ();
		
				GUI.EndGroup ();
		}
	
		public void AdjustCurrentHealth (int adj)
		{
		
				curHealth += adj;
		
				if (curHealth < 0)
						curHealth = 0;
		
				if (curHealth > maxHealth)
						curHealth = maxHealth;
		
				if (maxHealth < 1)
						maxHealth = 1;
		
				healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
		}
}
