using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    public static bool isGrounded;

    [Range(1, 10)]
    public float jumpVelocity;

    public float fallMultiplier = 2.5f;

    public float lowJumpMultiplier = 2.3f;

    public bool isSlamming;

    public float slamSpeed;


    Rigidbody rb;
    // Use this for initialization
    void Awake() {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update() {


        jump();

    }

    private void OnCollisionEnter(Collision collision) {

        
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
            isSlamming = false;

        }

    }


    private void OnCollisionExit(Collision collision) {

        if (collision.gameObject.tag == "Ground") {
            isGrounded = false;
        }
    }



    private void jump() {


        if (Input.GetButtonDown("Jump") && isGrounded) {

            rb.velocity = Vector3.up * jumpVelocity;
        }

        // added gravity for smoother jump
        if (rb.velocity.y < 0) {

            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;



        }

        // long jump (if the player holds the jump button)
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {

            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (!isGrounded && Input.GetButton("Slam")) {

            rb.velocity = new Vector3(0, slamSpeed, 0);
            
        }
    }


}
