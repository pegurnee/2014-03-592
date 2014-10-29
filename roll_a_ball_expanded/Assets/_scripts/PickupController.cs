using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour
{
		private bool canMove;
		private float counterOfTimePassed;
		private Vector3 movement;
		private float limitForHowLongToMove;
		private const float moveLimitLowerBound = 0.25f;
		private const float moveLimitUpperBound = 1.50f;
		private float speed;
		private const float speedLimitLowerBound = 0.5f;
		private const float speedLimitUpperBound = 2.0f;
		private Vector3 initialPosition;

		void Start ()
		{
				this.canMove = true;
				this.MoveInRandomDirectionForRandomAmountOfTime ();
				this.initialPosition = new Vector3 (this.gameObject.transform.position.x, 
		                                   this.gameObject.transform.position.y, 
		                                   this.gameObject.transform.position.z);
		}
	
		void Update ()
		{
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
				this.speed = Random.Range (PickupController.speedLimitLowerBound, PickupController.speedLimitUpperBound);
		}
	
		private void ResetTiming ()
		{
				this.limitForHowLongToMove = Random.Range (PickupController.moveLimitLowerBound, PickupController.moveLimitUpperBound);
				this.counterOfTimePassed = 0;
		}

		private void ChangeDirection ()
		{
				float moveHorizontal = Random.Range (-1.0f, 1.0f);
				float moveVertical = Random.Range (-1.0f, 1.0f);
		
				this.movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		}

		void KillOne (GameObject firstPickup, GameObject secondPickup)
		{
				if (firstPickup.GetInstanceID () < secondPickup.GetInstanceID ()) {
						Destroy (firstPickup);
				} else {
						Destroy (secondPickup);
				}

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
						Destroy (this.gameObject);
						break;
				case "pickup":
						this.KillOne (this.gameObject, other.gameObject);
						break;
				case "wall":
						this.canMove = false;
						break;
				default:
						break;
				}
		}
}