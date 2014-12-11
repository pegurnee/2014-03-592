using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	GameObject player;
	Vector3 movement;
	private float limitForHowLongToMove;
	private float moveLimitLowerBound = 0.25f;
	private float moveLimitUpperBound = 1.50f;
	private float speed;
	private float speedLimitLowerBound = 0.5f;
	private float speedLimitUpperBound = 2.0f; 
	private float counterOfTimePassed;

	// Use this for initialization
	void Start () {
		this.transform.parent = GameObject.FindGameObjectWithTag ("DynamicObjects").transform;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		this.counterOfTimePassed += Time.deltaTime;
		this.transform.Translate (this.movement * Time.deltaTime * this.speed, Space.World);
		if (this.counterOfTimePassed > this.limitForHowLongToMove) {
			this.MoveInRandomDirectionForRandomAmountOfTime ();
		}
	}

	void MoveInRandomDirectionForRandomAmountOfTime ()
	{
		this.ChangeDirection ();
		this.ComputeNewSpeed ();
		this.ResetTiming ();
	}
	private void ComputeNewSpeed ()
	{
		this.speed = Random.Range (this.speedLimitLowerBound, this.speedLimitUpperBound);
	}
	private void ResetTiming ()
	{
		this.limitForHowLongToMove = Random.Range (this.moveLimitLowerBound, this.moveLimitUpperBound);
		this.counterOfTimePassed = 0;
	}
	private void ChangeDirection ()
	{
		float moveHorizontal = Random.Range (-1.0f, 1.0f);
		float moveVertical = Random.Range (-1.0f, 1.0f);
		this.movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Bullet")){
			Destroy(this.gameObject);
		}
	}
}
