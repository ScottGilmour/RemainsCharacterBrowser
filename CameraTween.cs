using UnityEngine;
using System.Collections;

public class CameraTween : MonoBehaviour {

	public GameObject spot1, spot2, spot3;
	private GameObject curSpot;

	private float speed = 0.3f;
	private float startTime;
	private float journeyLength;
	private float smooth = 5.0f;

	private bool moveObject;

	// Use this for initialization
	void Start () {
		moveObject = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveObject) {
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;

			this.transform.position = Vector3.Lerp(this.transform.position, curSpot.transform.position, fracJourney);

			if (Vector3.Distance(this.transform.position, curSpot.transform.position) < 0.1f) {
				moveObject = false;
			}
		}
	}

	public void tweenTo (int spot) {
		switch (spot) {
			case 1:
				moveObject = true;
				curSpot = spot1;	
				startTime = Time.time;
				journeyLength = Vector3.Distance(this.transform.position, curSpot.transform.position);
			break;

			case 2:
				moveObject = true;
				curSpot = spot2;	
				startTime = Time.time;
				journeyLength = Vector3.Distance(this.transform.position, curSpot.transform.position);
			break;

			case 3:
				moveObject = true;
				curSpot = spot3;
				startTime = Time.time;
				journeyLength = Vector3.Distance(this.transform.position, curSpot.transform.position);
			break;
		}
	}
}
