using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	//object to follow
	public GameObject target;

	//camera follow parameters
	public float followSpeed;
	public float horizontalOffset;
	public float verticalOffset;
	public float minSpeed;

	private Vector3 normalizedVelocity;
	private Vector3 newCameraPosition;
	private float trackingSpeed;

	//LateUpdate() made for a jerky camera so this code was moved to FixedUpdate()
	void FixedUpdate() {
		//calculate desired new position of the camera based on the ball's velocity (direction) and offsets
		normalizedVelocity = Vector3.Normalize (target.rigidbody.velocity);
		newCameraPosition = target.transform.position - (normalizedVelocity*horizontalOffset) + verticalOffset*Vector3.up;

		//use the magnitude of the ball's velocity to smooth camera transitions, 
		//but we don't want the camera to be too slow
		trackingSpeed = target.rigidbody.velocity.magnitude;
		if (trackingSpeed <= minSpeed)
			trackingSpeed = minSpeed;

		//move camera to new position smoothly via lerp and keep the camera pointed at the ball
		transform.position = Vector3.Lerp(transform.position, newCameraPosition, Time.deltaTime * trackingSpeed * followSpeed);
		transform.LookAt(target.transform);
	}
}

