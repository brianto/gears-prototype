using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabber : MonoBehaviour {

	public Spinner spinner;
	public RangeValue myX;
	public int direction = 1;
	public float startX;

	// Use this for initialization
	void Start () {
		startX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		myX.current += spinner.speed * direction * Time.deltaTime;

		if (myX.isAtMax() || myX.isAtMin()) {
			direction *= -1;
		}
		transform.position = new Vector3(startX + myX.current, transform.position.y, transform.position.z);
	}
}
