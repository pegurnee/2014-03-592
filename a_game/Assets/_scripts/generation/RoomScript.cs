using UnityEngine;
using System.Collections;

public class RoomScript : MonoBehaviour
{
		public GameObject prefab;
		private GameObject[] walls = new GameObject[4];
		// Use this for initialization
		void Start ()
		{
				for (int i = 0; i < this.walls.Length; i++) {
						this.walls [i] = (GameObject)Instantiate (prefab);
						this.walls [i].transform.localScale = new Vector3 (this.transform.localScale.x / 2,
			                                                  this.transform.localScale.y * 2,
			                                                  this.transform.localScale.z / 2);
						this.walls [i].transform.parent = this.transform;
				}

				this.walls [0].transform.position = new Vector3 (this.transform.position.x, 
		                                                 0, 
		                                                 this.transform.position.z + this.transform.GetChild (0).localScale.z / 2);
				this.walls [1].transform.position = new Vector3 (this.transform.position.x + this.transform.GetChild (0).localScale.x / 2, 
		                                                 0, 
		                                                 this.transform.position.z);
				this.walls [2].transform.position = new Vector3 (this.transform.position.x, 
		                                                 0, this.transform.position.z - this.transform.GetChild (0).localScale.z / 2);
				this.walls [3].transform.position = new Vector3 (this.transform.position.x - this.transform.GetChild (0).localScale.x / 2, 
		                                                 this.transform.position.y, 
		                                                 this.transform.position.z);

				this.walls [0].transform.localScale += new Vector3 (this.transform.GetChild (0).localScale.x, 0, 0);
				this.walls [1].transform.localScale += new Vector3 (0, 0, this.transform.GetChild (0).localScale.z);
				this.walls [2].transform.localScale += new Vector3 (this.transform.GetChild (0).localScale.x, 0, 0);
				this.walls [3].transform.localScale += new Vector3 (0, 0, this.transform.GetChild (0).localScale.z);

				for (int i = 0; i < this.walls.Length; i++) {
						this.walls [i].renderer.material.mainTextureScale = new Vector2 (this.walls [i].transform.localScale.x * 2, this.walls [i].transform.localScale.z * 2);
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
