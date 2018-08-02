﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject bullet;
    public GameObject bulletHole;
    public float delayTime = 0.5f;
    public float enemyDamage = 40f;

    private float counter = 0;

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Mouse0) && counter > delayTime)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            counter = 0;

            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            if(Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform.tag == "Enemy")
                {
                    hit.transform.GetComponent<EnemyHealthBar>().RemoveHealth(enemyDamage);
                }
                else
                {
                    Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                }
            }

        }

        counter += Time.deltaTime;

    }

}
