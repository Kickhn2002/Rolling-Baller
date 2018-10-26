using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {


    [Range(1, 10)]
    public float jumpVelocity;

    public float fallMultiplier = 2.5f;

    public float lowJumpMultiplier = 2f;


    Rigidbody rb;
    // Use this for initialization
    void Awake() {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update() {


        if (Input.GetButtonDown("Jump")) {

            GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
        }

        if (rb.velocity.y < 0) {

            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;



        }

        else if (rb.velocity.y>0 && !Input.GetButton("Jump")) {

            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }
}
