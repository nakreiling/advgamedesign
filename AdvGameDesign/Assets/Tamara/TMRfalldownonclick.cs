using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TMRfalldownonclick : MonoBehaviour
{

    Animator anime;
    public int transition;

    

    public static int monies;
    private int count;
    public Text moniesText;
    public Component[] bones;
    public static Animator anim;
    public bool isDead;
    public static int counter;
    public Transform cameraTrans;
    public Rigidbody body;
    public static bool explosionHappens;
    

    // Use this for initialization
    void Start()
    {
        StartCoroutine(MyCoroutine());
        explosionHappens = false;
        anime = gameObject.GetComponent<Animator>();
        monies = 0;
        moniesText.text = "Money: " + monies.ToString();
        bones = gameObject.GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();
        isDead = false;
        anim.SetBool("isDead", true);

    }
    IEnumerator MyCoroutine()
    {
        if (explosionHappens == true)
        {
            KillRagdollExplosion();
            yield return 3;
            restoreRagdoll();
        }
    }



    // Update is called once per frame
    void Update()
    {
        MyCoroutine();
       // if(explosionHappens == true)
       // {
            
         //   Debug.Log("Message from grenade.cs recieved");
         //   monies += 200;
          //  KillRagdollExplosion();

        //}



        if (Input.GetButton("Fire1") && PlayerRayCasting.getIsHit() == true)
        {
            
            counter = 0;
            //anime.SetBool("isDead", true);
            if (count < 1)
            {
                if (WeaponSelect.selectedWeapon == 0)
                {
                    killRagdoll(0);
                    //  body.AddForce (cameraTrans.forward * 1000f);

                    monies += 10;
                }
                else if (WeaponSelect.selectedWeapon == 1)
                {
                    killRagdoll(100);
                    //body.AddForce(cameraTrans.forward * 3000f);
                    monies += 40;
                }

                else if (WeaponSelect.selectedWeapon == 2)
                {
                    killRagdoll(500);
                   // body.AddForce(cameraTrans.forward * 7000f);
                    monies += 70;
                }
                else if (WeaponSelect.selectedWeapon == 3)
                {

                   // killRagdoll(500);
                    // body.AddForce(cameraTrans.forward * 7000f);
                   // monies += 70;
                }
                count += 1;
            }
            moniesText.text = "Money: " + monies.ToString();
        }
        else if (counter >= 180)
        {
            isDead = false;
            //anim.SetBool("GetUpFromBelly", true);

            transition = Random.Range(0,9);

            anim.SetInteger("Transition", transition);

            restoreRagdoll();

        }
        else
        {
            //anime.SetBool("isDead", false);
            count = 0;
            counter++;
            body.velocity = cameraTrans.forward * 0f;
        }

    }
    void killRagdoll( int var)
    {
        
        anime.SetBool("isDead", false);
        foreach (Rigidbody ragdoll in bones)
        {
            // ragdoll.rotation= transform.rotation;
            ragdoll.isKinematic = false;
            


            ragdoll.AddForce(cameraTrans.forward * var);
          
        }
        anim.enabled = false;
       

    }
    public void KillRagdollExplosion()
    {
        monies += 200;
        anime.SetBool("isDead", false);
        foreach (Rigidbody ragdoll in bones)
        {
            // ragdoll.rotation= transform.rotation;
            ragdoll.isKinematic = false;

            ragdoll.AddExplosionForce(700f, transform.position, 7);

            //ragdoll.AddForce(cameraTrans.forward * var);

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
         
        
        anim.SetBool("isDead", false);
        anim.enabled = true;
    }
    
}
