using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PlayerRayCasting : MonoBehaviour
{

    public Camera cam;
    public LayerMask LayerMask;
    public static bool isHit;
    public Animator anim;
    public bool canBuy01, canBuy02, canBuy03, canBuy04;
    public static int weaponOne = 0;
    public static int weaponTwo = 0;
    public static int weaponThree = 0;
    public static int weaponFour = 0;
    public static bool blobPlayed;
    public static float rayDistance;
   

    // Use this for initialization
    void Start()
    {
        //find the game object that has the Player tag
        //player = GameObject.FindWithTag("Player");
        setHit(false);
        anim = GetComponent<Animator>();
        canBuy01 = false;
        canBuy02 = false;
        canBuy03 = false;
        canBuy04 = false;
        weaponOne = 0;
        weaponTwo = 0;
        weaponThree = 0;
        weaponFour = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(falldownonclick.monies >= 100 && weaponOne == 0)
        {
            canBuy01 = true;
        }

        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Mouse clicked");
            Vector3 start = cam.transform.position;
            Vector3 dir = cam.transform.forward * 100f;
            RaycastHit hit;

            if (Physics.Raycast(start, dir, out hit, Mathf.Infinity))
            {
                Debug.Log("Raycast initiated");
                if (hit.collider.gameObject.tag == "YBot")
                {
                    Debug.Log("I shot a person.");
                    setHit(true);
                    blobPlayed = false;
                    rayDistance = hit.distance; 
                    anim.SetBool("GetUpFromBack", true);
                    Debug.Log(getIsHit().ToString());
                    Debug.DrawRay(start, dir, Color.red, 1f);
                }
                else if(hit.collider.gameObject.tag == "Weapon01")//also condition for it to be bought if it hasnt already(TO COME)
                {
                    Debug.Log("I shot the glock.");
                   // setHit(true);

                    Debug.Log(getIsHit().ToString());
                    Debug.DrawRay(start, dir, Color.red, 1f);
                    if (falldownonclick.monies >=100  && weaponOne == 0)
                    {
                        Debug.Log("You buy glock.");
                        canBuy01 = false;
                        weaponOne++;
                        
                    }
                    else if(falldownonclick.monies < 100 || weaponOne != 0)
                    {
                        Debug.Log("No sir!");
                    }

                }
                else if (hit.collider.gameObject.tag == "Weapon02")//also condition for it to be bought if it hasnt already(TO COME)
                {
                    Debug.Log("I shot the blaster.");
                    // setHit(true);

                    Debug.Log(getIsHit().ToString());
                    Debug.DrawRay(start, dir, Color.red, 1f);
                    if (falldownonclick.monies >= 500 && weaponTwo == 0)
                    {
                        Debug.Log("You buy blaster.");
                        canBuy02 = false;
                        weaponTwo++;

                    }
                    else if (falldownonclick.monies < 500 || weaponTwo != 0)
                    {
                        Debug.Log("No pewpew!");
                    }

                }
                else if (hit.collider.gameObject.tag == "Weapon03")//also condition for it to be bought if it hasnt already(TO COME)
                {
                    Debug.Log("I shot the grenade.");
                    // setHit(true);

                    Debug.Log(getIsHit().ToString());
                    Debug.DrawRay(start, dir, Color.red, 1f);
                    if (falldownonclick.monies >= 800 && weaponThree == 0)
                    {
                        Debug.Log("You buy grenade.");
                        canBuy03= false;
                        weaponThree++;

                    }
                    else if (falldownonclick.monies < 800 || weaponThree != 0)
                    {
                        Debug.Log("No BOOM!");
                    }

                }
                else if (hit.collider.gameObject.tag == "Weapon04")//also condition for it to be bought if it hasnt already(TO COME)
                {
                    Debug.Log("I shot the shotgun.");
                    // setHit(true);

                    Debug.Log(getIsHit().ToString());
                    Debug.DrawRay(start, dir, Color.red, 1f);
                    if (falldownonclick.monies >= 2000 && weaponFour == 0)
                    {
                        Debug.Log("You buy shotgun.");
                        canBuy04 = false;
                        weaponFour++;

                    }
                    else if (falldownonclick.monies < 800 || weaponThree != 0)
                    {
                        Debug.Log("No BOOM!stick");
                    }

                }
                else
                {
                    Debug.Log("I missed");
                    Debug.DrawRay(start, dir, Color.red, 10f);

                }
            }
            Debug.DrawRay(start, dir, Color.red, 1f);
            //EditorApplication.isPaused = true;
        }
    }

    public static void setHit(bool var)
    {
        isHit = var;

    }

    public static bool getIsHit()
    {
        return isHit;
    }
}