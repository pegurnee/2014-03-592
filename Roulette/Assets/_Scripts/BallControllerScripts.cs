using UnityEngine;
using System.Collections;
/*
 * Cade Sperlich
 * Eddie Gurnee
 */

public class BallControllerScripts : MonoBehaviour
{
		public Transform theBowl;
		public float launchSpeed;
		private bool ballIsStopped;
		private int framesInTrigger;
		private int pocket;

		void Start ()
		{
				ballIsStopped = false;
				framesInTrigger = 0;
		}

		void Update ()
		{
				if (Input.GetKeyDown ("space"))
						launchBall ();
		}

		void OnTriggerEnter (Collider collider)
		{
				framesInTrigger = 0;
		}

		void OnTriggerStay (Collider collider)
		{
				if (++framesInTrigger > 500 && !this.ballIsStopped) {
						ballIsStopped = true;
						string name = collider.gameObject.name;
						string num = name.Substring ("Pocket".Length);
						this.pocket = num.Equals ("00") ? 31 : int.Parse (num);

						Debug.Log (collider.gameObject.name);
						Debug.Log (collider.gameObject.name.Substring ("Pocket".Length));
						Debug.Log (this.pocket);
				}
		}

		public void launchBall ()
		{
				this.ballIsStopped = false;
				this.framesInTrigger = 0;
				this.pocket = -1;

				//randomly place the ball along the inner edge of the bowl
				rigidbody.isKinematic = true;
				float degrees = Random.Range (0, 360);
				Vector3 radius = new Vector3 (0.0f, 0.0f, 7.5f) + new Vector3 (0.0f, 2.5f, 0.0f);
				transform.position = theBowl.position + radius;
				transform.RotateAround (theBowl.position, Vector3.up, degrees);

				//launch the ball along the tangent line 
				rigidbody.isKinematic = false;
				rigidbody.velocity = Vector3.zero;
				Vector3 tangent = Vector3.Cross (transform.position, Vector3.up).normalized;
				rigidbody.AddForce (tangent * launchSpeed, ForceMode.Impulse);
		}

		void OnTriggerExit (Collider collider)
		{
				framesInTrigger = 0;
		}

		public bool isStopped ()
		{
				return ballIsStopped;
		}

		public int getPocket ()
		{
				return this.pocket;
		}
}
