using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour {


    public Text levelComplete;

	// Use this for initialization
	void Start () {

        levelComplete.text = "";
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider collider) {

        if (collider.gameObject.tag == ("Player")) {

            levelComplete.text = "you win";

            
        }
    }
}
