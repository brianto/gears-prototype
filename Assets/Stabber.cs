using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabber : MonoBehaviour {

	public Spinner spinner;
	public RangeValue myX;
	public int direction = 1;
	public float startX;


	
	// Update is called once per frame
	void Update () {
		startX = spinner.transform.position.x;
		myX.current += spinner.speed/3 * direction * Time.deltaTime;

		if (myX.isAtMax() || myX.isAtMin()) {
			direction *= -1;
		}

		transform.position = new Vector3(startX + myX.current, transform.position.y, spinner.transform.position.z);
	}
}
