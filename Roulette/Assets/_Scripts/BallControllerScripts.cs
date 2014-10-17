using UnityEngine;
using System.Collections;

public class BallControllerScripts : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnCollisionEnter (Collision collision)
		{
		print ("gah");
			this.rigidbody.AddForce (collision.relativeVelocity * collision.relativeVelocity.magnitude * 100 * Time.deltaTime);
		}
}
