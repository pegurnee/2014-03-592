using UnityEngine;
using System.Collections;

public class WheelControllerScript : MonoBehaviour
{
		public GameObject theBall;
		public GameObject theGameController;
		private float speed;
		private BallControllerScripts ballScript;
		private GUIController guiScript;

		// Use this for initialization
		void Start ()
		{
				this.initSpeed ();
				this.ballScript = theBall.GetComponent<BallControllerScripts> ();
				this.guiScript = this.theGameController.GetComponent<GUIController> ();
		}

		void FixedUpdate ()
		{	
				this.transform.eulerAngles += new Vector3 (0.0f, 0.0f, .002f * this.speed);

				if (ballScript.isStopped () == true) {
						this.speed -= .05f;
				}
				if (this.speed <= 0.0f) {
						this.speed = 0.0f;
						this.guiScript.newBet ();
				}
		}

		public void initSpeed ()
		{
				this.speed = 100;
		}
}
