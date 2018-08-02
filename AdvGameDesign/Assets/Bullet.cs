using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        speed = 15.0f;
        Destroy(this.gameObject, 2);
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= transform.forward * Time.deltaTime * speed; 
	}

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().Hit(10);
            Destroy(this.gameObject);

        }
    }
}
