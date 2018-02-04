using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseGearPlacer : MonoBehaviour {
	
	public List<GameObject> gearsToPlaceDown;
	private Queue<GameObject> gearQueue;
	private GameObject currentGearToPlaceDown;
	private GameObject previousGear = null;

	public static int PLACED_DOWN_STATE = 1;


	void Start() {
		foreach (GameObject gear in gearsToPlaceDown) {
			gear.SetActive (false);
			gear.GetComponent<StateController>().changeState(0);
		}


		gearQueue = new Queue<GameObject> (gearsToPlaceDown);
		currentGearToPlaceDown = getGearToPlaceDown ();

	}

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			currentGearToPlaceDown.GetComponent<StateController>().changeState (PLACED_DOWN_STATE);

			if (previousGear != null) {
				previousGear.GetComponent<Spinner> ().Drive (currentGearToPlaceDown.GetComponent<Spinner> ());
			}

			previousGear = currentGearToPlaceDown;
			currentGearToPlaceDown = getGearToPlaceDown ();
		}
	}

	GameObject getGearToPlaceDown() {
		GameObject nextGear = gearQueue.Dequeue ();

		nextGear.SetActive (true);

		return nextGear;
	}

}
