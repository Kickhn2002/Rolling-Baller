using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    public Transform target;

    public float lookSmooth = 0.09f;

    public Vector3 offsetFromTarget = new Vector3(0, 6, -8);

    public float xTilt = 10;

    Vector3 destination = Vector3.zero;

    PlayerMouvement charController;

    float rotateVel = 0;

    private void Start() {
        SetCameraTarget(target);

        }

    void SetCameraTarget(Transform t) {

        target = t;

        if (target != null) {

            if (target.GetComponent<PlayerMouvement>()) {

                charController = target.GetComponent<PlayerMouvement>();
            }

            else
                Debug.LogError("The camera's target needs a character ontroller");
        }

        else
            Debug.LogError("Your camera needs a target");

    }

    private void FixedUpdate() {
        MoveToTarget();
        LookAtTarget();

    }

    void MoveToTarget() {

        destination = charController.TargetRotation * offsetFromTarget;
        destination += target.position;
        transform.position = destination;

    }

    void LookAtTarget() {

        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);

        transform.rotation = Quaternion.Euler(xTilt, eulerYAngle,0);

    }


}





