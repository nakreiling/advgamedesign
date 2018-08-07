using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour {



    public static int selectedWeapon = 0;
    public static int count = 0;
    public static int grenadeFlag = 0;

    // Use this for initialization
    void Start()
        {
        SelectWeapon();

        }

        // Update is called once per frame
        void Update()
        {
        
            int previousWeaponSelected = selectedWeapon;

        //if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        // {
        //   if (selectedWeapon >= transform.childCount - 1)
        //       selectedWeapon = 0;
        //   else
        //       selectedWeapon++;

        //}
        //if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        // {
        //     if (selectedWeapon <= 0)
        //         selectedWeapon = transform.childCount - 1;
        //     else
        //        selectedWeapon--;

        // }
        if (Input.GetKeyDown(KeyCode.Alpha0) && PlayerRayCasting.weaponOne >= 0)
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && PlayerRayCasting.weaponOne >=1)
        {
            selectedWeapon = 1;
            grenadeFlag = 0;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && PlayerRayCasting.weaponTwo >= 1)
        {
            selectedWeapon = 2;
            grenadeFlag = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && PlayerRayCasting.weaponThree >= 1)
        {
            selectedWeapon = 3;
            grenadeFlag = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && PlayerRayCasting.weaponFour >= 1)
        {
            selectedWeapon = 4;
            grenadeFlag = 0;
        }



        if (previousWeaponSelected != selectedWeapon)
            {
                SelectWeapon();
            }

        }
        void SelectWeapon()
        {
            int i = 0;
        foreach (Transform weapon in transform)
        {
           
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;

            

        }


        }

    }




