using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class falldownonclick : MonoBehaviour
{

    Animator anime;

    public static int monies;
    private int count;
    public Text moniesText;
    public Component[] bones;
    public Animator anim;
    public bool isDead;
    public int counter;
    public Transform cameraTrans;
    public Rigidbody body;
    

    // Use this for initialization
    void Start()
    {
        anime = gameObject.GetComponent<Animator>();
        monies = 0;
        moniesText.text = "Money: " + monies.ToString();
        bones = gameObject.GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();
        isDead = false;
        anime.SetBool("GetUpFromback", false);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && PlayerRayCasting.getIsHit() == true)
        {
            Debug.Log("Killing Ragdoll");
            killRagdoll();
            counter = 0;
            // PlayerRayCasting.getIsHit();
            //anime.SetBool("GetUpFromBack", true);
            anime.SetBool("GetUpFromBack", false);
            if (count < 1)
            {
                if (WeaponSelect.selectedWeapon == 0)
                {
                    body.AddForce (cameraTrans.forward * 1000f);

                    monies += 10;
                }
                else if (WeaponSelect.selectedWeapon == 1)
                {
                    monies += 40;
                }

                else if (WeaponSelect.selectedWeapon == 2)
                {
                    monies += 70;
                }
                count += 1;
            }
            moniesText.text = "Money: " + monies.ToString();
        }
        else if (counter >= 180)
        {
            isDead = false;
        
            restoreRagdoll();

        }
        else
        {
            anime.SetBool("GetUpFromBack", false);
            count = 0;
            counter++;
            body.velocity = cameraTrans.forward * 0f;
        }
    }

    void killRagdoll()
    {

        foreach (Rigidbody ragdoll in bones)
        {
           // ragdoll.rotation= transform.rotation;
            ragdoll.isKinematic = false;
            
        }

        

        anim.enabled = false;
        
    }

    void restoreRagdoll()
    {
        PlayerRayCasting.setHit(false);
       
        foreach (Rigidbody ragdoll in bones)
        {
            ragdoll.isKinematic = true;
        }
         
        anim.enabled = true;
        anim.SetBool("GetUpFromBack", true);
    }
    
}
public class BodyPart
{
    public Transform transform;
    public Vector3 storedPosition;
    public Quaternion storedRotation;
}