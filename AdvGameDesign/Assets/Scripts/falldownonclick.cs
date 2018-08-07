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
    public static Animator anim;
    public bool isDead;
    public static int counter;
    public Transform cameraTrans;
    public Rigidbody body;
    public static bool explosionHappens;
    public bool flag;

    public AudioClip blob;
    public AudioClip punch;
    public AudioClip gunShot;
    public AudioClip laserShot;
    public AudioClip shotgun_fire_1;


    // Use this for initialization
    void Start()
    {
        explosionHappens = false;
        flag = false;
        anime = gameObject.GetComponent<Animator>();
        monies = 0;
        moniesText.text = "Money: " + monies.ToString();
        bones = gameObject.GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();
        isDead = false;
        anim.SetBool("isDead", true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            giveMonies();
        }

      if(explosionHappens == true)
        {
            flag = true;
        }

        //(explosionHappens==true) used to be in if statement
        if ((Input.GetButton("Fire1") && PlayerRayCasting.getIsHit() == true))
        {
            
            counter = 0;
            //anime.SetBool("isDead", true);
            if (count < 1)
            {
                if (WeaponSelect.selectedWeapon == 0 && PlayerRayCasting.rayDistance < 5)
                {
                    killRagdoll(0);
                    //  body.AddForce (cameraTrans.forward * 1000f);
                    SoundManager.instance.PlaySingle(punch);
                    monies += 10;
                }
                else if (WeaponSelect.selectedWeapon == 1)
                {
                    killRagdoll(100);
                    //body.AddForce(cameraTrans.forward * 3000f);
                    SoundManager.instance.PlaySingle(gunShot);
                    monies += 40;
                }

                else if (WeaponSelect.selectedWeapon == 2)
                {
                    killRagdoll(500);
                    // body.AddForce(cameraTrans.forward * 7000f);
                    SoundManager.instance.PlaySingle(laserShot);
                    monies += 70;
                }
                else if (flag == true)
                {
                    killRagdoll(200);


                    Debug.Log("Message from grenade.cs recieved");
                }
                else if (WeaponSelect.selectedWeapon == 4)
                {
                    killRagdoll(1000);
                    // body.AddForce(cameraTrans.forward * 7000f);
                    SoundManager.instance.PlaySingle(shotgun_fire_1);
                    monies += 150;
                }
                count += 1;
            }
            moniesText.text = "Money: " + monies.ToString();
        }
        else if (counter >= 180)
        {
            isDead = false;
            //anim.SetBool("GetUpFromBelly", true);
          
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
            
            if(explosionHappens == true)
            {
                ragdoll.AddExplosionForce(200f, transform.position, 7);
                Debug.Log("Yoyoyoyoyyooyoyyo");
            }
            else
            ragdoll.AddForce(cameraTrans.forward * var);
          
        }
        anim.enabled = false;
        explosionHappens = false;
       

    }
    public void KillRagdollExplosion()
    {

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
        if (!PlayerRayCasting.blobPlayed)
        {
            SoundManager.instance.PlaySingle(blob);
            PlayerRayCasting.blobPlayed = true;
        }

        PlayerRayCasting.setHit(false);
        foreach (Rigidbody ragdoll in bones)
        {
            ragdoll.isKinematic = true;
        }
         
        
        anim.SetBool("isDead", false);
        anim.enabled = true;
    }
    
    void giveMonies()
    {
        monies += 500;

    }
}
public class BodyPart
{
    public Transform transform;
    public Vector3 storedPosition;
    public Quaternion storedRotation;
}