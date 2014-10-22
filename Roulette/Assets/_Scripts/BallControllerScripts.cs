using UnityEngine;
using System.Collections;

public class BallControllerScripts : MonoBehaviour
{
	public Transform theBowl;
	public float launchSpeed;

	private bool ballIsStopped;
	private int framesInTrigger;

	void Start ()
	{
		ballIsStopped = false;
		framesInTrigger = 0;
	}

	void Update()
	{
		if (Input.GetKeyDown("space"))
			launchBall();
	}

	void OnTriggerEnter (Collider collider)
	{
		framesInTrigger = 0;
	}

	void OnTriggerStay (Collider collider)
	{
		if (++framesInTrigger > 500)
			ballIsStopped = true;
	}

	void launchBall() 
	{
		//randomly place the ball along the inner edge of the bowl
		rigidbody.isKinematic = true;
		float degrees = Random.Range(0, 360);
		Vector3 radius = new Vector3(0.0f, 0.0f, 7.5f) + new Vector3(0.0f, 2.5f, 0.0f);
		transform.position = theBowl.position + radius;
		transform.RotateAround(theBowl.position, Vector3.up, degrees);

		//launch the ball along the tangent line 
		rigidbody.isKinematic = false;
		rigidbody.velocity = Vector3.zero;
		Vector3 tangent = Vector3.Cross (transform.position, Vector3.up).normalized;
		rigidbody.AddForce(tangent * launchSpeed, ForceMode.Impulse);
	}

	void OnTriggerExit (Collider collider)
	{
		framesInTrigger = 0;
	}

	public bool isStopped ()
	{
		return ballIsStopped;
	}
}
