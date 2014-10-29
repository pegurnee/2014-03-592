using UnityEngine;
using System.Collections;
/*
 * Cade Sperlich
 * Eddie Gurnee
 */

public class GUIController : MonoBehaviour
{
		public GameObject theBall;
		public GameObject theWheel;
		public GameObject theGameController;
		private BallControllerScripts ballScript;
		private WheelControllerScript wheelScript;
		private BetController betScript;
		private bool betPlaced;
		private const int offsetX = 10;
		private const int offsetY = 10;
		private const int littleButtonSize = 3;
		private const int littleBoxSize = 30;
		private const int littleBoxOffest = 2;
		private const int limitOfSpaces = 32;

		// Use this for initialization
		void Start ()
		{
				this.betPlaced = false;
				this.ballScript = theBall.GetComponent<BallControllerScripts> ();
				this.wheelScript = theWheel.GetComponent<WheelControllerScript> ();
				this.betScript = this.theGameController.GetComponent<BetController> ();
		}
	
		// Update is called once per frame
		void Update ()
		{

		}

		void OnGUI ()
		{
				if (!this.betPlaced) {
						GUI.Box (new Rect (offsetX, offsetY, 
			                    littleBoxOffest + 4 * (littleBoxSize + littleBoxOffest), 
			                   littleBoxOffest + 8 * (littleBoxSize + littleBoxOffest)), "");
						for (int i = 0; i < limitOfSpaces; i++) {
								if (GUI.Button (new Rect (offsetX + littleBoxOffest 
										+ (i % 4) * (littleBoxSize + littleBoxOffest), 
								                   offsetY + littleBoxOffest 
										+ (i / 4) * (littleBoxSize + littleBoxOffest), 
				                   				littleBoxSize, 
				                   				littleBoxSize), 
				         					(i == limitOfSpaces - 1) ? "00" : "" + i)) {
										this.betScript.increaseBet (i);
								}
						}
						if (GUI.Button (new Rect (
				offsetX + littleBoxOffest + (littleBoxSize + littleBoxOffest) / 2, 
				offsetX + littleBoxOffest * 2 + 8 * (littleBoxSize + littleBoxOffest), 
				(littleBoxSize + littleBoxOffest) * 3, 
				20), "Place Bet")) {
								this.betPlaced = true;
								this.ballScript.launchBall ();
								this.wheelScript.initSpeed ();
						}
				}
		}

		public void newBet ()
		{
				this.betScript.payoutBets (this.ballScript.getPocket ());
				this.betPlaced = false;
		}
}
