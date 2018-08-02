using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBallHit : MonoBehaviour {
    public GameObject ybot;

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Dummy") {

            
            ybot.SendMessage("killRagdoll");

        }
        Destroy(gameObject, 3);

    }
}
