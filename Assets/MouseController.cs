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

    void OnSelectSpinner(Spinner spinner) {
        if (this.source == null) {
            this.source = spinner;
            this.source.Highlight(true);
            return;
        }

        this.source.Connect(spinner);

        this.source.Highlight(false);
        this.source = null;
    }
}
