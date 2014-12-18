using UnityEngine;
using System.Collections;

public class DungeonGenerator : MonoBehaviour {
	private enum RoomType {
		Spawn,
		Hunter,
		Boss,
		Empty,
		Treasure,
		StairsUp,
		StairsDown
	}
	private enum RoomState {
		Entered,
		Cleared,
		Unreached
	}
	private class RoomData {
		private RoomType type;
		private RoomState state;
	}

	const int MAX_ROOMS_PER_FLOOR = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void generateFloor() {

		}
}
