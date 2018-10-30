using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraSpeed : MonoBehaviour {

    public float extraSpeed = 50;
    private float boostedSpeed;

    // Use this for initialization
    void Start() {
        boostedSpeed = this.transform.parent.GetComponent<Rotate>().rotationSpeed + extraSpeed;
    }

    // Update is called once per frame
    void Update() {

    }


    private void OnTriggerEnter(Collider collider) {
        // if the speed of rotation is not the accelerated speed


        if (this.transform.parent.GetComponent<Rotate>().rotationSpeed != boostedSpeed) {
            this.transform.parent.GetComponent<Rotate>().rotationSpeed = boostedSpeed;

        }


    }
}