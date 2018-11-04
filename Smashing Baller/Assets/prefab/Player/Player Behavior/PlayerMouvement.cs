using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour {

    public float inputDelay = 0.1f;
    public float fowardVel = 12;
    public float rotateVel = 100;

     Quaternion targetRotation;

    Rigidbody rBody;
    float fowardInput, turnInput;


    public Quaternion TargetRotation {

        get { return targetRotation; }
    }

    void Start() {

        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();

        else
            Debug.LogError("The character needs a rigidbody");
    }

    void GetInput() {
        fowardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

    }

    private void Update() {

   
        
    }

    private void FixedUpdate() {
        GetInput();
        Turn();

        Run();
        Turn();
    }

    void Run() {
        if (Mathf.Abs(fowardInput) > inputDelay) {

            //move
            rBody.velocity = transform.forward * fowardInput * fowardVel;
        }

        else {
           
            rBody.velocity = new Vector3(0, rBody.velocity.y, 0);
        }





    }

    void Turn() {

        targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
        transform.rotation = targetRotation;

    }


}
