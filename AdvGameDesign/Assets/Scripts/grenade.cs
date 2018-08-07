using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour {
    public float delay = 3f;
    bool hasExploded = false;
    float countdown;
    public float radius = 5f;
    public float force = 700f;
    public GameObject explosionEffect;
	// Use this for initialization
	void Start () {
        countdown = delay;
        
    }
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
           // grenade.Destroy(gameObject, 3);//grenade.Destroy(gameObject, 1);
        }
	}
    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] collidersToDestroy= Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in collidersToDestroy)
        {
       
            Destructible dest = nearbyObject.GetComponent<Destructible>();
            if(dest != null)
            {
                dest.Destroy();
            }
        }
        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                if(rb.gameObject.tag == "YBot"&& falldownonclick.explosionHappens == false)
                {
                    
                    Debug.Log("Explosion hit dummy");
                    falldownonclick.explosionHappens = true;
                }
                
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
       
            Debug.Log("BOOM!");
        Destroy(gameObject, 1);
        //hasExploded = false;
        
    }
    
}
