using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCastingPickUp : MonoBehaviour {

    public float distanceToSee;
    public RaycastHit whatIHit;
    public GameObject player;

	// Use this for initialization
	void Start () {
        //find the game object that has the Player tag
        player = GameObject.FindWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

        //if player interacts with a collider from other objects
        if (Physics.Raycast(this.transform.position, transform.forward, out whatIHit, distanceToSee))
        {

            Debug.Log("I touched something");
            
            //if player presses E
            if(Input.GetKeyDown (KeyCode.E))
            {
                Debug.Log("I picked up " + whatIHit.collider.gameObject.name);

                //check if the object the player is colliding with has a keyCard tag
                if (whatIHit.collider.tag == "KeyCards")
                {
                    //accesses the keycards script and destroy the object if the key E is pressed
                    if (whatIHit.collider.gameObject.GetComponent<KeyCards>().key == KeyCards.Keycards.RedKey)
                    {
                        player.GetComponent<Inventory>().hasRedKey = true;
                        Destroy(whatIHit.collider.gameObject);
                    }
                    if (whatIHit.collider.gameObject.GetComponent<KeyCards>().key == KeyCards.Keycards.GreyKey)
                    {
                        player.GetComponent<Inventory>().hasRedKey = true;
                        Destroy(whatIHit.collider.gameObject);
                    }
                    if (whatIHit.collider.gameObject.GetComponent<KeyCards>().key == KeyCards.Keycards.BrownKey)
                    {
                        player.GetComponent<Inventory>().hasRedKey = true;
                        Destroy(whatIHit.collider.gameObject);
                    }
                }

            }
        }
		
	}
}
