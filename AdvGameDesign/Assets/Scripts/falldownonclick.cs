using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falldownonclick : MonoBehaviour {

    Animator anime;

	// Use this for initialization
	void Start () {
        anime = gameObject.GetComponent<Animator>();
        Debug.Log("bitchin'");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1"))
        {
            anime.SetBool("FallDown", true);
        }
        else
        {
            anime.SetBool("FallDown", false);
        }

	}
}
