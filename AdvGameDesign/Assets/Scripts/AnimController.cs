
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AnimController : MonoBehaviour {
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
   
        if (Input.GetButton("Fire1"))
        {

            anim.SetBool("Punch", true);
            anim.SetBool("Object01|Object01Action", true);
        }

        else
        {
            anim.SetBool("Punch", false);
            anim.SetBool("Object01|Object01Action", false);
        
        }
	}
}
