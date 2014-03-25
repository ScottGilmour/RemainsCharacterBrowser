using UnityEngine;
using System.Collections;

public class GUIOverlay : MonoBehaviour {

	void OnGUI() {
		GUI.Label (new Rect (0, 0, 100, 50), "Scavenger");
		GUI.Label (new Rect (20, 20, 100, 50), "Stamina: 8");
		GUI.Label (new Rect (20, 40, 100, 50), "Health: 8");
		GUI.Label (new Rect (20, 60, 100, 50), "Attack: 2");
		GUI.Label (new Rect (20, 80, 100, 50), "Movement: 1");
		GUI.Label (new Rect (20, 100, 100, 50), "Sight: 12");
	}
}
