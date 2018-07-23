using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCasting : MonoBehaviour {

    public float distanceToSee;

    //anything the player touches/collides with will be stored in this variable
    RaycastHit WhatIHit;

        GameObject cube;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed primary button");
            Destroy(WhatIHit.collider.gameObject);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Pressed secondary button");
        }
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Pressed middle click");
        }

        /*if(Physics.Raycast(this.transform.position, this.transform.forward, out WhatIHit, distanceToSee))
        {
            Debug.Log("I touched " + WhatIHit.collider.gameObject.name);
            Destroy(WhatIHit.collider.gameObject);
        } */
	}
}
