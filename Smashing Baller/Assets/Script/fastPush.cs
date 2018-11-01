using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the gameObject moves back and and forth between 2 locations. It has a delay before returning to each location.

public class fastPush : MonoBehaviour {

    private Vector3 from;
    private Vector3 goTo;
    private Vector3 startingPos;
    public Transform destination;
    private Vector3 destinationPos;
    public float stopDuration;
    public float speed;
    private float firstLerp = 0.05f;
    private float temp;

    // Use this for initialization
    void Start() {

        startingPos = transform.position;
        from = startingPos;
        destinationPos = destination.transform.position;
        goTo = destinationPos;
        temp = firstLerp;
        StartCoroutine(wait());

    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {


        transform.position = Vector3.Lerp(from, goTo, firstLerp);
        firstLerp += speed;

    }




    private IEnumerator wait() {

        while (true) {

            if (transform.position == destinationPos) {
              
                from = destinationPos;
                goTo = startingPos;
                firstLerp = temp;
  yield return new WaitForSeconds(5);
            }

          else  if (transform.position == startingPos) {
               
                from = startingPos;
                goTo = destinationPos;
                firstLerp = temp;
 yield return new WaitForSeconds(5);
            }


        }

    }


}
