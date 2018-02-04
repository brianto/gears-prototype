using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

    private Spinner source;

    void Start() {
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Spinner clicked = this.GetClickedSpinner();

            if (clicked != null) {
                this.OnSelectSpinner(clicked);
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            this.source = null;
            Spinner clicked = this.GetClickedSpinner();

            if (clicked != null) {
                this.OnDisconnectSpinner(clicked);
            }
        }
    }

    Spinner GetClickedSpinner() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 250)) {
            Debug.Log(hit.transform.gameObject.name);
            Spinner spinner = hit.transform.gameObject.GetComponent<Spinner>();

            if (spinner != null) {
                return spinner;
            }
        }

        return null;
    }

    void OnDisconnectSpinner(Spinner spinner) {
        spinner.Disconnect();
    }

    void OnSelectSpinner(Spinner spinner) {
        if (this.source == null) {
            this.source = spinner;
            this.source.Highlight(true);
            return;
        }

        Spinner driver = FindDriver(this.source, spinner);

        driver.Drive(driver == this.source ? spinner : this.source);

        this.source.Highlight(false);
        this.source = null;
    }

    static Spinner FindDriver(Spinner a, Spinner b) {
        if (a.speed > 0) {
            return a;
        }

        if (b.speed > 0) {
            return b;
        }

        return a;
    }
}
