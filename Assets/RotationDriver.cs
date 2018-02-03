using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationDriver : MonoBehaviour {

    public Spinner[] spinners;

    public float speed;

    void Start() {
    }
	
    // Update is called once per frame
    void Update() {
        foreach (Spinner spinner in this.spinners) {
            spinner.speed = this.speed;
        }
    }
}
