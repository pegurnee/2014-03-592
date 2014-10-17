using UnityEngine;
using System.Collections;

public class WheelControllerScript : MonoBehaviour
{
		public GameObject theWheel;
		private bool isSpinning = true;
		private int speed;

		// Use this for initialization
		void Start ()
		{
				this.isSpinning = false;
				this.speed = 0;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (this.isSpinning) {
						this.transform.Rotate (new Vector3 (0.0f, 0.0f, 1) * this.speed * Time.deltaTime);
						this.speed = this.speed - 1;
						if (this.speed == 0) {
								this.isSpinning = false;
						}
				}
				if (!this.isSpinning) {
						if (Input.GetKeyDown ("space")) {
								this.isSpinning = true;
								this.speed = 1200;
						}
				}
		}

		void FixedUpdate ()
		{

		}

		void StartSpinning (float axis)
		{
				this.isSpinning = true;
				this.speed = 1200;
		}
}
