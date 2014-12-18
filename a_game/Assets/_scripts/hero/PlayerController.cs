using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
		private int speed = 5;
		public GameObject prefab;
		int direction; 

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKey ("up")) {
						this.gameObject.transform.Translate ((new Vector3 (0f, 0f, 1f)) * Time.deltaTime * this.speed);
						direction = 0;
				} else if (Input.GetKey ("down")) {
						this.gameObject.transform.Translate ((new Vector3 (0f, 0f, -1f)) * Time.deltaTime * this.speed);
						direction = 2;
				} else if (Input.GetKey ("right")) {
						this.gameObject.transform.Translate ((new Vector3 (1f, 0f, 0f)) * Time.deltaTime * this.speed);
						direction = 1;
				} else if (Input.GetKey ("left")) {
						this.gameObject.transform.Translate ((new Vector3 (-1f, 0f, 0f)) * Time.deltaTime * this.speed);
						direction = 3;
				}

				if (Input.GetKey ("w")) {
						this.fire (0);
				} else if (Input.GetKey ("a")) {
						this.fire (3);
				} else if (Input.GetKey ("s")) {
						this.fire (2);
				} else if (Input.GetKey ("d")) {
						this.fire (1);
				}
		}

		private void fire (int direction)
		{
				GameObject clone;
				clone = Instantiate (prefab, this.transform.position, Quaternion.identity) as GameObject;
				clone.GetComponent<BulletController> ().setDirection (direction);
		}

		void FixedUpdate ()
		{

		}

		public int getDirection ()
		{
				return direction;
		}
}
