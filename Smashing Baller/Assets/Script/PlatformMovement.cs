using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    public Transform destination;
    private Vector3 startingPostion;

    [Tooltip("if the platforms moves back and forth or not")]
    public bool repeatable = false;
    public float speed = 1.0f;
    public float duration = 3.0f;

    float startTime, totalDistance;

    // Use this for initialization
    IEnumerator Start() {
        startTime = Time.time;
        startingPostion = transform.position;
        totalDistance = Vector3.Distance(startingPostion, destination.position);

        while (repeatable) {

            yield return RepeatLerp(startingPostion, destination.position, duration);
            yield return RepeatLerp(destination.position, startingPostion, duration);
        }





    }


    // Update is called once per frame
    void Update() {

        if (!repeatable) {

            float currentDuration = (Time.time - startTime) * speed;

            float journeyFraction = currentDuration / totalDistance;

            this.transform.position = Vector3.Lerp(transform.position, destination.position, journeyFraction);
        }




    }
    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time) {

        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f) {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }

    
    private void OnCollisionEnter(Collision collision) {

        // the players moves with the platform
        if (collision.gameObject.tag == "Player") {
            Vector3 originalScale = collision.transform.lossyScale;
            collision.collider.transform.SetParent(transform);
            collision.transform.localScale = originalScale;
        }
    }

    private void OnCollisionExit(Collision collision) {
        
        // the player does not move with the platform after exiting the platform
        if(collision.gameObject.tag == "Player") {
            collision.collider.transform.SetParent(null);

        }
    }


}
