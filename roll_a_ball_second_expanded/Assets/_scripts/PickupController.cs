using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour
{
		private bool canMove;
		private float counterOfTimePassed;
		private Vector3 movement;
		private float limitForHowLongToMove;
		private float moveLimitLowerBound = 0.25f;
		private float moveLimitUpperBound = 1.50f;
		private float speed;
		private float speedLimitLowerBound = 0.5f;
		private float speedLimitUpperBound = 2.0f;
		private Vector3 initialPosition;
		private GameController theGameController;
		private int size;
		private bool dead;

		void Start ()
		{
				this.dead = false;
				this.size = 0;
				this.initialPosition = new Vector3 (this.gameObject.transform.position.x, 
		                                    this.gameObject.transform.position.y, 
		                                    this.gameObject.transform.position.z);
				this.canMove = true;
				this.MoveInRandomDirectionForRandomAmountOfTime ();
				this.theGameController = GameObject.FindWithTag ("gameController").GetComponent<GameController> ();
		}
	
		void Update ()
		{
				if (this.dead) {
						Destroy (this.gameObject);
				}
				if (this.canMove) {
						this.transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
				} else {
						if (Input.GetKeyDown ("space")) {
								this.ResetPosition ();
						}
				}
		
		}

		void FixedUpdate ()
		{
				this.counterOfTimePassed += Time.deltaTime;
				if (this.canMove) {
						this.transform.Translate (this.movement * Time.deltaTime * this.speed, Space.World);
		
						if (this.counterOfTimePassed > this.limitForHowLongToMove) {
								this.MoveInRandomDirectionForRandomAmountOfTime ();
						} 
				}
		}

		void MoveInRandomDirectionForRandomAmountOfTime ()
		{
				this.ChangeDirection ();
				this.ComputeNewSpeed ();
				this.ResetTiming ();
		}
	
		private void ComputeNewSpeed ()
		{
				this.speed = Random.Range (this.speedLimitLowerBound, this.speedLimitUpperBound);
		}
	
		private void ResetTiming ()
		{
				this.limitForHowLongToMove = Random.Range (this.moveLimitLowerBound, this.moveLimitUpperBound);
				this.counterOfTimePassed = 0;
		}

		private void ChangeDirection ()
		{
				float moveHorizontal = Random.Range (-1.0f, 1.0f);
				float moveVertical = Random.Range (-1.0f, 1.0f);
		
				this.movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		}

		void ResetPosition ()
		{
				this.transform.position = this.initialPosition;
				this.canMove = true;
		}

		void OnCollisionEnter (Collision other)
		{
				switch (other.gameObject.tag) {
				case "player":
						this.theGameController.PlayerKilled (this.gameObject);
						break;
				case "pickup":
						this.theGameController.KillOne (this.gameObject, other.gameObject);
						break;
				case "wall":
						this.canMove = false;
						break;
				default:
						break;
				}
		}

		public void speedUp ()
		{
				this.moveLimitLowerBound *= 0.95f;
				this.moveLimitUpperBound *= 0.95f;
				this.speedLimitLowerBound *= 1.2f;
				this.speedLimitUpperBound *= 1.2f;
		}

		public int getSize ()
		{
				return this.size;
		}

		public void powerUp ()
		{
				this.gameObject.renderer.material.color = new Color ((this.gameObject.renderer.material.color.r * 1.3f), 
		                                                    this.gameObject.renderer.material.color.g,
		                                                    this.gameObject.renderer.material.color.b);
				this.gameObject.transform.localScale *= 1.1f;
				this.speedUp ();
				this.size++;
		}
	
		public void makeDead ()
		{
				this.dead = true;
		}
	
		public bool isDead ()
		{
				return this.dead;
		}
}