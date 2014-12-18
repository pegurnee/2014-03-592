using UnityEngine;
using System.Collections;

public class DungeonGenerator : MonoBehaviour
{
		//3 spawn, 3 hunter, 2 empty, 1 treasure, 1 boss
		private enum RoomType
		{
				Spawn,
				Hunter,
				Boss,
				Empty,
				Treasure,
				NotARoom
		}

		private enum RoomState
		{
				Entered,
				Cleared,
				Unreached
		}

		private class RoomData
		{
				public int number;
				public RoomType type;
				public RoomState state;
				public int[] connectingRooms = new int[4];
		}

		public GameObject roomPrefab;
		const int MAX_ROOMS_PER_FLOOR = 20;
		RoomData[] rooms;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		private void generateFloor ()
		{
				this.rooms = new RoomData[MAX_ROOMS_PER_FLOOR];
				this.rooms [0] = new RoomData ();
				this.rooms [0].connectingRooms [3] = -1;
				this.rooms [0].number = 0;
				this.rooms [0].state = RoomState.Cleared;
				this.rooms [0].type = RoomType.Empty;

				int i = 1;
				while (i++ < MAX_ROOMS_PER_FLOOR) {
						this.rooms [i] = new RoomData ();
						this.rooms [i].number = i;

						int roomSeed = Random.Range (1, 10);
						switch (roomSeed) {
						case 1:
						case 2:
						case 3:
								this.rooms [i].type = RoomType.Spawn;
								break;
						case 4:
						case 5:
						case 6:
								this.rooms [i].type = RoomType.Hunter;
								break;
						case 7:
						case 8:
								this.rooms [i].type = RoomType.Empty;
								break;
						case 9:
								this.rooms [i].type = RoomType.Boss;
								break;
						case 10:
								this.rooms [i].type = RoomType.Treasure;
								break;
						}

						this.rooms [0].type = RoomType.Empty;
						this.rooms [0].connectingRooms [3] = -1;
						this.rooms [0].number = 0;
						this.rooms [0].state = RoomState.Cleared;
				}
		}
}
