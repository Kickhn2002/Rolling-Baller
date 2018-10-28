using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvementCube : MonoBehaviour {

    public float movementSpeed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime* movementSpeed;
        var y = Input.GetAxis("Vertical") * Time.deltaTime* movementSpeed;

        transform.Translate(x, 0, y);

		
	}

}
