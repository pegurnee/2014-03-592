using UnityEngine;
using System.Collections;

public class TrackingCamera : MonoBehaviour {
	public GameObject target;

	void LateUpdate() {
		transform.LookAt(target.transform);
	}
}
