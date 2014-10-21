using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Camera mainCam;
	public Camera followCam;
	public Camera trackingCam;

	// Use this for initialization
	void Start () {
		followCam.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
