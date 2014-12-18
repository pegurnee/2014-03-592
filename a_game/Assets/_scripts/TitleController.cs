using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour
{
		public GameObject titlePrefab;
		public GameObject subtitlePrefab;
		private GameObject title;
		private GameObject subtitle;
		private bool firstLoad;
		private const int WIDTH = 800;
		// Use this for initialization
		void Start ()
		{
				this.firstLoad = true;
				this.title = Instantiate (titlePrefab) as GameObject;
				this.subtitle = Instantiate (subtitlePrefab) as GameObject;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (this.firstLoad) {
						if (Input.anyKey) {
								this.firstLoad = false;
								this.title.transform.Translate (new Vector3 (0, 0.1f), Space.Self);
								Destroy (this.subtitle);
						}
				}
		}

		void OnGUI ()
		{
				if (!this.firstLoad) {
						GUI.Box (new Rect (Screen.width / 2 - WIDTH / 2,
			                   Screen.height / 2, 
			                   WIDTH, 
			                   200), 
			         "Choose a character:");
	
						string[] heroes = {"Fighter", "Archer", "Wizard", "Healer"};

						int yoffset = 150;
						int xoffset = 60;
						int xbuttonsize = 80;
						for (int i = 0; i < 4; i++) {
								if (GUI.Button (new Rect (xoffset 
										+ Screen.width / 2 - WIDTH / 2 
										+ (xoffset * 2 + xbuttonsize) * i, 
				                          Screen.height / 2 + yoffset, 
				                          xbuttonsize, 
				                          20), 
				                heroes [i])) {
										Application.LoadLevel (1);
								}
						}
				}
		}
}
