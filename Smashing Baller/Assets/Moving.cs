using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {

    public float speed;
    private float _speed;

    public float gravity = 20.0f;
    private float _gravity;

    public float jumpSpeed = 8.0f;

    private CharacterController controller;
    private Vector3 movement;
    private bool isGrounded;
    private bool run;
    private bool jump;
    private float foward;
    private float side;




    void Start() {

        controller = GetComponent<CharacterController>();
        _speed = (0.3f * speed);
        _gravity = -gravity;

    }

    private void Update() {


        setGrounded();
        setMovement();
        isRunning();
        wantToJump();


    }

    private void FixedUpdate() {



        if (isGrounded) {

            if (run) {

                movement = new Vector3(foward, 0.0f, side);
                movement = transform.TransformDirection(movement);
                movement *= _speed;
            }
            else {

                movement = new Vector3(foward, 0.0f, side);
                movement = transform.TransformDirection(movement);
                movement *= _speed*0.7f;

            }




        }

        if (!isGrounded) {



        }

        movement = new Vector3(movement.x, _gravity, movement.z);
        movement *= _speed;

        controller.Move(movement);

    }

    private void setGrounded() {

        if (controller.isGrounded)
            isGrounded = true;

        else
            isGrounded = false;

    }

    private void setMovement() {

        foward = (Input.GetAxis("Horizontal"));
        side = (Input.GetAxis("Vertical"));
    }

    private void wantToJump() {
        if (Input.GetButton("Jump")) {

            jump = true;
        }

        else jump = false;

    }

    private void isRunning() {

        if (Input.GetKey(KeyCode.LeftShift))
            run = true;

        else
            run = false;
    }

}
