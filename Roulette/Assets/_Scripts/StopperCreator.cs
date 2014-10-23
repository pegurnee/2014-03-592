using UnityEngine;
using System.Collections;

public class StopperCreator : MonoBehaviour
{
		public Collider stopper;
		// Use this for initialization
		void Start ()
		{
				for (int i = 0; i < 8; i++) {
						Collider newStopper = (Collider)Instantiate (stopper, transform.position + new Vector3 (0.0f, 1.7f, 7f), Quaternion.identity);

						newStopper.transform.Rotate (257, 0, 0);

						if (i % 2 == 0) {
								newStopper.transform.Rotate (0, 0, 90);
						}
						newStopper.transform.RotateAround (transform.position, Vector3.up, (360 / 8) * i);
						newStopper.transform.parent = transform;
				}
		}
}
