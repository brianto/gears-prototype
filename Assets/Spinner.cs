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
        this.connected = new HashSet<Spinner>();
    }
	
    void Update() {
        this.transform.RotateAround(this.transform.position, this.axis, this.speed * Time.deltaTime);
    }

    public void Connect(Spinner spinner) {
        if (spinner == this || this.connected.Contains(spinner)) {
            return;
        }

        this.connected.Add(spinner);
        spinner.connected.Add(this);

        spinner.speed = this.speed;
        spinner.axis *= -this.axis; // TODO fix for non-plane gears
    }

    public void Highlight(bool show) {
        // TODO
    }
}
