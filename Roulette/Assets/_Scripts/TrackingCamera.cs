using UnityEngine;
using System.Collections;
/*
 * Cade Sperlich
 * Eddie Gurnee
 */

public class TrackingCamera : MonoBehaviour
{
		public GameObject target;

		void LateUpdate ()
		{
				transform.LookAt (target.transform);
		}
}
