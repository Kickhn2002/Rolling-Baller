using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour {

    public float angularDrag;

    public float speed;

    public float airspeed;



    private Rigidbody rb;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update() {

        var moveHorizontal = Input.GetAxis("Horizontal");


        var moveVertival = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertival);

        if (PlayerJump.isGrounded) {
            rb.AddForce(movement * speed);
            rb.angularDrag = angularDrag;
        }


        else if (!PlayerJump.isGrounded) {
            rb.AddForce(movement * airspeed);
            rb.angularDrag = angularDrag;

        }


    }
}
