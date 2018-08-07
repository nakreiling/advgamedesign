using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeThrower : MonoBehaviour {
     float throwForce = 50f;
    public GameObject grenadePrefab;
    public static bool grenadeThrown;
    //public bool thrown=true;
    // public int grenCount = 0;

    private void Start()
    {
        grenadeThrown = false;
    }

    // Update is called once per frame
    void Update() {
        
        if (Input.GetButton("Fire1") && PlayerRayCasting.weaponThree >= 1 && WeaponSelect.grenadeFlag == 1)//
        {
            // thrown = false;
            //  grenCount++;
            // if (thrown == false && grenCount <=1)
            // {
            if (!grenadeThrown)
            {
                ThrowGrenade();
                grenadeThrown = true;
            }
            // }
           // grenCount = 0;
        }
	}
    void ThrowGrenade()
    {
        Debug.Log("Grenade spawned");
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    
        }
      
    }


       