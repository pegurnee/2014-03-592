using UnityEngine;
using System.Collections;

public class BossRoomCameraController : MonoBehaviour {
	public GameObject player;

	private float ypos = 15;

	void Start () {

	}
	
	void Update () {
			transform.position = new Vector3(this.player.transform.position.x, 
		                                 this.ypos, 
		                                 this.player.transform.position.z);
	}
}
