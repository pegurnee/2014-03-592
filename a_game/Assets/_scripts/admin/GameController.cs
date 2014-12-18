using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
		public GameObject roomPrefab;
		public GameObject theCamera;
		public GameObject thePlayer;
		public static int numrooms = 1;

		// Use this for initialization
		void Start ()
		{
				Camera.main.backgroundColor = Color.black;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void createRoom (int direction)
		{
				numrooms++;
				
				if (numrooms < 6) {
						GameObject room = (GameObject)Instantiate (roomPrefab);
//				room.transform.position = (new Vector3 (room.transform.position.x + (20 * numrooms), 
//		                             room.transform.position.y, 
//		                             room.transform.position.z));
//				
//				this.theCamera.transform.position = (new Vector3 (this.theCamera.transform.position.x + (20 * numrooms), 
//		                                       15, 
//		                                       0));
//				this.thePlayer.transform.position = (new Vector3 (this.thePlayer.transform.position.x + (20 * numrooms), 
//		                                                  this.thePlayer.transform.position.y, 
//		                                                  this.thePlayer.transform.position.z));

						int roomSeed = Random.Range (1, 10);
						switch (roomSeed) {
						case 1:
						case 2:
						case 3:
						case 4:
								room.GetComponent<RoomScript> ().makeSpawner ();
								break;
						case 5:
						case 6:
						case 7:
						case 8:
								room.GetComponent<RoomScript> ().makeHunters ();
								break;
								break;
						case 9:
//						room.GetComponent<RoomScript> ().makeBossman ();
								break;
						case 10:
			//treasure
								break;
						}
				} else {

				}
//				switch (direction) {
//				case 0:
//						
//						break;
//				case 1:
//						break;
//				case 2:
//						break;
//				case 3:
//						break;
//				}
		}
}
