using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanAnimation : MonoBehaviour {

    public Animator anim;

    private float inputH;
    private float inputV;
    private bool run;

    // Use this for initialization
    void Start() {

        anim = GetComponent<Animator>();
        run = false;

    }

    // Update is called once per frame
    void Update() {
        emotes();

        if (Input.GetKey(KeyCode.LeftShift)) {
            run = true;
        }

        else {
            run = false;
        }

        


        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        anim.SetBool("run", run);


    }

    private void emotes() {

        if (Input.GetKeyDown("1")) {

            anim.Play("WAIT01", -1, 0f);
        }

        if (Input.GetKeyDown("2")) {

            anim.Play("WAIT02", -1, 0f);
        }

        if (Input.GetKeyDown("3")) {

            anim.Play("WAIT03", -1, 0f);
        }

        if (Input.GetKeyDown("4")) {

            anim.Play("WAIT04", -1, 0f);
        }
    }
}
