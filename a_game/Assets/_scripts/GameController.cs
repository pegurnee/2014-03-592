using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public static GameObject roomPrefab;
		// Use this for initialization
		void Start ()
		{
				Camera.main.backgroundColor = Color.black;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public static void createRoom (int direction)
		{
				
		GameObject room = (GameObject)Instantiate (roomPrefab);

				switch (direction) {
				case 0:
						
						break;
				case 1:
						break;
				case 2:
						break;
				case 3:
						break;
				}
		}
}
