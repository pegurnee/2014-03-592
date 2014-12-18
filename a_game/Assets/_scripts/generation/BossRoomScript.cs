using UnityEngine;
using System.Collections;

public class BossRoomScript : MonoBehaviour
{
	public GameObject wallPrefab;
	public GameObject doorPrefab;
	public GameObject bossPrefab;
	private GameObject[] walls = new GameObject[4];
	private GameObject[] doors = new GameObject[4];
	private float width;
	private float height;
	// Use this for initialization
	void Start ()
	{
		this.createWalls ();
		this.height = this.transform.GetChild (0).localScale.z;
		this.width = this.transform.GetChild (0).localScale.x;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
	
	private void createDoors ()
	{
		for (int i = 0; i < this.doors.Length; i++) {
			this.doors [i] = (GameObject)Instantiate (doorPrefab);
			this.doors [i].transform.localScale = new Vector3 (this.transform.localScale.x / 2,
			                                                   this.transform.localScale.y * 2.5f,
			                                                   this.transform.localScale.z / 2);
			this.doors [i].transform.parent = this.transform;
			
		}
		this.doors [0].transform.localScale += new Vector3 (this.transform.GetChild (0).localScale.x / 4, 0, 0);
		this.doors [1].transform.localScale += new Vector3 (0, 0, this.transform.GetChild (0).localScale.z / 3);
		this.doors [2].transform.localScale += new Vector3 (this.transform.GetChild (0).localScale.x / 4, 0, 0);
		this.doors [3].transform.localScale += new Vector3 (0, 0, this.transform.GetChild (0).localScale.z / 3);
		
		
		this.doors [0].transform.position = new Vector3 (this.transform.position.x, 
		                                                 0, 
		                                                 this.transform.position.z + this.transform.GetChild (0).localScale.z / 2);
		this.doors [1].transform.position = new Vector3 (this.transform.position.x + this.transform.GetChild (0).localScale.x / 2, 
		                                                 0, 
		                                                 this.transform.position.z);
		this.doors [2].transform.position = new Vector3 (this.transform.position.x, 
		                                                 0, this.transform.position.z - this.transform.GetChild (0).localScale.z / 2);
		this.doors [3].transform.position = new Vector3 (this.transform.position.x - this.transform.GetChild (0).localScale.x / 2, 
		                                                 this.transform.position.y, 
		                                                 this.transform.position.z);
		
		
		
		for (int i = 0; i < this.doors.Length; i++) {
			this.doors [i].renderer.material.mainTextureScale = 
				new Vector2 (this.doors [i].transform.localScale.x * 2, 
				             this.doors [i].transform.localScale.z * 2);
		}
	}
	
	private void createWalls ()
	{
		for (int i = 0; i < this.walls.Length; i++) {
			this.walls [i] = (GameObject)Instantiate (wallPrefab);
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
			this.walls [i].renderer.material.mainTextureScale = 
				new Vector2 (this.walls [i].transform.localScale.x * 2, 
				             this.walls [i].transform.localScale.z * 2);
		}
	}
}