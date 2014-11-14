using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
		private int numKilled;
		private int playerScore;
		private int maxPickups;
		private AudioSource wildcat;
		private AudioSource lastLap;
		private GameObject[] pickups;
		public GameObject prefab;
		private int numberOfObjects = 6;
		private float radius = 8f;
	
		private void newWave ()
		{
				for (int i = 0; i < numberOfObjects; i++) {
						float angle = i * Mathf.PI * 2 / numberOfObjects;
						Vector3 pos = new Vector3 (Mathf.Cos (angle), 0.1f, Mathf.Sin (angle)) * radius;
						Instantiate (prefab, pos, Quaternion.identity);

						this.pickups = GameObject.FindGameObjectsWithTag ("pickup");
						this.maxPickups = pickups.Length;
						this.numKilled = 0;
				}
		}
	
		void Start ()
		{
				this.numKilled = 0;
				this.pickups = GameObject.FindGameObjectsWithTag ("pickup"); 
				this.maxPickups = pickups.Length;
				this.playerScore = 0;

				this.wildcat = GetComponents<AudioSource> () [1];
				this.lastLap = GetComponents<AudioSource> () [0];
		}

		void Update ()
		{
				if (!this.wildcat.isPlaying && !this.lastLap.isPlaying) {
						this.wildcat.Play ();
				}
				if (Input.GetKeyDown ("x")) {
						this.newWave ();
				}
		}
	
		public void KillOne (GameObject firstPickup, GameObject secondPickup)
		{
				int fSize = firstPickup.GetComponent<PickupController> ().getSize ();
				int sSize = secondPickup.GetComponent<PickupController> ().getSize ();
				if (fSize != sSize) {
						if (fSize < sSize) {
								KillPickup (firstPickup);
								secondPickup.GetComponent<PickupController> ().powerUp ();
						} else {
								KillPickup (secondPickup);
								firstPickup.GetComponent<PickupController> ().powerUp ();
						}
			
				} else {
						if (firstPickup.GetInstanceID () < secondPickup.GetInstanceID ()) {
								KillPickup (firstPickup);
								secondPickup.GetComponent<PickupController> ().powerUp ();
						} else {
								KillPickup (secondPickup);
								firstPickup.GetComponent<PickupController> ().powerUp ();
						}
				}
		}

		public void PlayerKilled (GameObject nowDeadPickup)
		{
				KillPickup (nowDeadPickup);
				this.playerScore++;
		}
	
		private void KillPickup (GameObject nowDeadPickup)
		{
				if (!nowDeadPickup.GetComponent<PickupController> ().isDead ()) {
						nowDeadPickup.GetComponent<PickupController> ().makeDead ();
						if (++this.numKilled == this.maxPickups - 1) {
								this.wildcat.Pause ();
								this.lastLap.Play ();
								this.wildcat.pitch *= 1.1f;
						}
						foreach (GameObject pickup in pickups) {
								if (pickup != null) {
										pickup.GetComponent<PickupController> ().speedUp ();
								}
						}
						this.wildcat.pitch *= 1.1f;
				}
		}
}
