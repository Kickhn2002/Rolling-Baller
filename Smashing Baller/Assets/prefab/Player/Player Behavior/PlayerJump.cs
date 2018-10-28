using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    private float distToGround = 0.8f;
    private float gravityScale = 1.0f;
    private float globalGravity = -9.81f;

    [Range(1, 50)]
    public float jumpVelocity;

    public float fallMultiplier = 0.05f;

    public float lowJumpMultiplier = 0.07f;

    bool isGrounded;
    bool jumpRequest;
    bool slamRequest;

    public bool test;


    public float slamSpeed;

    Rigidbody rb;


    // Use this for initialization
    void Awake() {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

    }

    // Update is called once per frame
    void Update() {


        getJumpRequest();
        getGroundedRequest();
        getSlamRequest();

    }

    private void FixedUpdate() {

        if (slamRequest)
            Slam();

        else
            Jump();

    }



    private void Slam() {
        if (slamRequest) {

            rb.velocity = new Vector3(0, -slamSpeed, 0);

        }


    }



    // check if the player wants to jump
    private void getJumpRequest() {


        if (Input.GetButtonDown("Jump") && isGrounded) {

            jumpRequest = true;
        }

    }


    private void Jump() {





        if (jumpRequest) {
            //  rb.velocity = Vector3.up * jumpVelocity;
            rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            jumpRequest = false;
        }

        // added gravity for smoother jump
        if (rb.velocity.y < 0) {

            test = rb.velocity.y < 0;
            Vector3 gravity = globalGravity * fallMultiplier * Vector3.up;
            rb.AddForce(gravity, ForceMode.Acceleration);



        }

        // long jump (if the player holds the jump button)
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            Vector3 gravity = globalGravity * lowJumpMultiplier * Vector3.up;

            rb.AddForce(gravity, ForceMode.Acceleration);
        }

        else {
            Vector3 gravity = globalGravity * Vector3.up;
            rb.AddForce(gravity, ForceMode.Acceleration);
        }
    }

    private void getSlamRequest() {

        slamRequest = (!isGrounded && Input.GetButton("Slam"));


    }



    private void getGroundedRequest() {

        isGrounded = Physics.Raycast(transform.position, Vector3.down, distToGround);

    }
}
