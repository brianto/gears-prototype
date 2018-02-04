using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {

    // TODO gear ratio

    private Spinner driver;
    private HashSet<Spinner> drivees;

    public float speed;

    public Vector3 axis;

    // Use this for initialization
    void Start() {
        this.drivees = new HashSet<Spinner>();
    }

    void Update() {
        foreach (Spinner spinner in this.drivees) {
            spinner.speed = this.speed;
        }

        this.transform.RotateAround(this.transform.position, this.axis, this.speed * Time.deltaTime);
    }

    public void Drive(Spinner spinner) {
        if (spinner == this || this.drivees.Contains(spinner)) {
            return;
        }

        this.drivees.Add(spinner);
        spinner.driver = this;

        spinner.axis = -1 * this.axis; // TODO fix for non-plane gears
    }

    public void Disconnect() {
        if (this.driver != null) {
            this.driver.drivees.Remove(this);
            this.speed = 0;
            this.driver = null;
        }

        List<Spinner> originalDrivees = this.drivees.ToList();
        foreach (Spinner spinner in originalDrivees) {
            spinner.Disconnect();
        }

        this.drivees.Clear();
    }

    public void Highlight(bool show) {
        // TODO
    }
}
