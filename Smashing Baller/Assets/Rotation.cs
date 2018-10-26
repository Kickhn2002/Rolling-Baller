using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    private float rotationSpeed = 60.0f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        var x = -Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * rotationSpeed;


        transform.Rotate(0, 0, x);
        transform.Rotate(y, 0, 0);


    }
}
