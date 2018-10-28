using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    private float distToGround = 0.5f;

    [Range(1, 10)]
    public float jumpVelocity;

    public float fallMultiplier = 0.05f;

    public float lowJumpMultiplier = 0.07f;



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






    private void jump() {


        if (Input.GetButtonDown("Jump") && isGrounded()) {

            rb.velocity = Vector3.up * jumpVelocity;
        }

        // added gravity for smoother jump
        if (rb.velocity.y < 0) {

            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier ) * Time.deltaTime;



        }

        // long jump (if the player holds the jump button)
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {

            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
        }

        if (!isGrounded() && Input.GetButton("Slam")) {

            rb.velocity = new Vector3(0, slamSpeed, 0);
            
        }
    }



    private bool isGrounded() {

        return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }
}
