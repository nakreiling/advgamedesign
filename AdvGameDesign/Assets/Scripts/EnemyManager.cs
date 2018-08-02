using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    private HealthBarManager m_health;

	// Use this for initialization
	void Start () {
        m_health = GetComponentInChildren<HealthBarManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Damage")
        {
            m_health.reduceHealth(10);
        }
    }
}
