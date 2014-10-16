using UnityEngine;
using System.Collections;

public class BallAudio : MonoBehaviour {

	public float audioClipSpeed = 10.0f;
	public float pitchMin;
	public float pitchMax;
	public float volMin;
	public float volMax;


	void OnCollisionEnter(Collision collision) {
		audio.Play ();
	}

	void Update() {
		float p = rigidbody.velocity.magnitude / audioClipSpeed;
		audio.pitch = Mathf.Clamp (p, pitchMin, pitchMax);
		audio.volume = Mathf.Clamp (p, volMin, volMax);

	}

	/*void OnCollisionExit(Collision collision) {
		audio.Stop();
	}*/
}
