using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {

    // Use this for initialization
    void Start() {
		
    }
	
    void Update() {
        this.transform.RotateAround(this.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
