using UnityEngine;
using System.Collections;

public class rotator : MonoBehaviour {

	void Update () {
		this.transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
