using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerRayCasting : MonoBehaviour
{

    public Camera cam;
    public LayerMask LayerMask;
    public static bool isHit;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        //find the game object that has the Player tag
        //player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        anim.SetBool("fallDown", false);


    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("FallDown", false);
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
                    anim.SetBool("fallDown", true);
                    //anim.SetBool("GetUpFromBack", true);
                    Debug.Log(getIsHit().ToString());
                    Debug.DrawRay(start, dir, Color.red, 10.0f);
                }
                else
                {
                    Debug.Log("I missed");
                    Debug.DrawRay(start, dir, Color.red, 10f);

                }
            }
            Debug.DrawRay(start, dir, Color.red, 10f);
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