﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    public Transform playerTransform;

    private Vector3 cameraOffset;


    [Range(0.0f, 1.0f)]
    public float SmoothFactor = 0.5f;
	// Use this for initialization
	void Start () {

        cameraOffset = transform.position - playerTransform.position;
		
	}

    // Update is called once per frame
    void Update() {
    
		
	}

     void LateUpdate(){

        Vector3 newPos = playerTransform.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        
    }

}


