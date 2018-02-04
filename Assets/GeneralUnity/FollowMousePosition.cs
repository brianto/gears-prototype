using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMousePosition : MonoBehaviour {

	float yAxis = 0f;
	Vector3 mousePosition;

	void Update() {
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePosition.y = yAxis;
		transform.position = mousePosition;
	}
}
