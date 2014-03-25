using UnityEngine;
using System.Collections;

public class Swipe : MonoBehaviour {
	private Vector2 potentialSwipePos;
	private float potentialStartTime;
	private bool potentialSwipe;
	private bool zoomedIn;
	private float swipeDirection;
	private int currentSpot;

	// Use this for initialization
	void Start () {
		potentialSwipe = false;
		zoomedIn = false;
		Screen.orientation = ScreenOrientation.Landscape;
		currentSpot = 2;
		Camera.main.GetComponent<CameraTween>().tweenTo(currentSpot);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}

		if (Input.touchCount > 0) {
			Touch curTouch = Input.GetTouch (0);

			if (curTouch.tapCount > 1) {
				Camera.main.GetComponent<CameraTween>().tweenTo(3);
			}

			switch (curTouch.phase) {
				case TouchPhase.Began:
						potentialSwipePos = curTouch.position;
						potentialStartTime = Time.time;
						potentialSwipe = true;
					break;

				case TouchPhase.Moved:
						//If we go above a certain position, cancel swipe
						if (Mathf.Abs (curTouch.position.y - potentialSwipePos.y) > 200.0f) {
								potentialSwipe = false;
						}
					break;

				case TouchPhase.Ended:
						float timeElapsed = Time.time - potentialStartTime;
						float swipeDist = (curTouch.position - potentialSwipePos).magnitude;	
						swipeDirection = curTouch.position.x - potentialSwipePos.x;
						
						if (swipeDirection > 1.0f) {
							if (potentialSwipe && (timeElapsed > 0.1f) && (swipeDist > 0.5f)) {
								RotateLeft ();
							}
						} else if (swipeDirection < -1.0f) {
							if (potentialSwipe && (timeElapsed > 0.1f) && (swipeDist > 0.5f)) {
								RotateRight ();
							}
						}
					break;
			}
		} else {
			potentialSwipe = false;
		}
	}

	void RotateRight ()
	{
		if (currentSpot > 0)
			currentSpot--;
		else if (currentSpot == 1) 
			currentSpot = 3;

		Camera.main.GetComponent<CameraTween>().tweenTo(currentSpot);
	}

	void RotateLeft ()
	{
		if (currentSpot < 4)
			currentSpot++;
		else if (currentSpot == 3) 
			currentSpot = 1;

		Camera.main.GetComponent<CameraTween>().tweenTo(currentSpot);
	}
}
