using UnityEngine;
using System.Collections;
/*
 * Cade Sperlich
 * Eddie Gurnee
 */

public class CameraController : MonoBehaviour {

	public bool spinPhase = true;
	public Camera[] cameras;
	// Use this for initialization
	void Start () {

		cameraEnabler(cameras[0], true);
		cameraEnabler(cameras[1], false);
		cameraEnabler(cameras[2], false);

		StartCoroutine ("CameraSwitching");
	}

	IEnumerator CameraSwitching()
	{
		int cameraSelector = 1;
		while (spinPhase)
		{
			yield return new WaitForSeconds(3.0f);

			for (int i = 0; i < 3; i++){
				if (cameraSelector == i)
					cameraEnabler(cameras[i], true);
				else
					cameraEnabler(cameras[i], false);
			}
			if (++cameraSelector > 2)
				cameraSelector = 0;
		}
	}

	void cameraEnabler(Camera camera, bool enable) 
	{
		if (enable){
			camera.enabled = true;
			camera.GetComponent<AudioListener>().enabled = true;
		}
		else {
			camera.enabled = false;
			camera.GetComponent<AudioListener>().enabled = false;
		}
	}

}
