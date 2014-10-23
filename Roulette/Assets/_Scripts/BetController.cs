using UnityEngine;
using System.Collections;

public class BetController : MonoBehaviour
{
		private const int limit = 32;
		private int[] bets = new int[limit];

		// Use this for initialization
		void Start ()
		{
				this.resetBets ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void increaseBet (int betlocation)
		{
				this.bets [betlocation]++;
//				Debug.Log ("Location: " + betlocation + "\nValue: " + this.bets [betlocation]);
		}

		public void resetBets ()
		{
				for (int i = 0; i < limit; i++) {
						this.bets [i] = 0;
				}
		}

		public int payoutBets (int rollResult)
		{
				return this.bets [rollResult] * 40;
		}
}
