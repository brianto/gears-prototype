using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {

	public MonoBehaviour[] behaviourPerStates;
	public int defaultState;

	private int currentState = 0;

	public void changeState(int newState) {
		behaviourPerStates [currentState].enabled = false;
		currentState = newState;
		behaviourPerStates [currentState].enabled = true;
	}
		
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
