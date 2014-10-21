using UnityEngine;
using System.Collections;

public class WheelControllerScript : MonoBehaviour
{
	public GameObject theBall;

	private float speed;
	private BallControllerScripts ballScript;

	// Use this for initialization
	void Start ()
	{
		this.speed = 100;
		this.ballScript = theBall.GetComponent<BallControllerScripts> ();
	}

	void FixedUpdate ()
	{	
		this.transform.eulerAngles += new Vector3 (0.0f, 0.0f, .002f * this.speed);

		if (ballScript.isStopped () == true)
			this.speed -= .05f;
		if (this.speed <= 0.0f)
			this.speed = 0.0f;

	}

}
