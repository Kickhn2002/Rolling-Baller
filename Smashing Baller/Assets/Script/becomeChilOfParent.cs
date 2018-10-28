using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class becomeChilOfParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision) {

        // the players moves with the platform
        if (collision.gameObject.tag == "Player") {

            collision.collider.transform.SetParent(transform.parent);

        }
    }

    private void OnCollisionExit(Collision collision) {

        // the player does not move with the platform after exiting the platform
        if (collision.gameObject.tag == "Player") {
            collision.collider.transform.SetParent(null);

        }
    }
}
