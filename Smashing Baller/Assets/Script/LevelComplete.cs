using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour {


    public Text levelComplete;

	// Use this for initialization
	void Awake () {

        levelComplete.text = "";
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == ("Player")) {

            levelComplete.text = "you win";

            
        }
    }
}
