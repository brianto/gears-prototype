using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {

    // TODO gear ratio

    private HashSet<Spinner> connected;

    public float speed;

    public Vector3 axis;

    // Use this for initialization
    void Start() {
    }
	
    void Update() {
        this.transform.RotateAround(this.transform.position, this.axis, this.speed * Time.deltaTime);
    }

    public void Connect(Spinner spinner) {
        this.speed = spinner.speed;
        this.axis *= -1;
    }
}
