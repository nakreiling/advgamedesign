using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

    public GameObject destroyedObject;
	
	// Update is called once per frame
	public void Destroy () {
        Instantiate(destroyedObject, transform.position, transform.rotation);

        Destroy(gameObject);
	}
}
