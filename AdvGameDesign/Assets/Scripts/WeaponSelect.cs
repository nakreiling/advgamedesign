using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour {


        
        public static int selectedWeapon = 0;

    // Use this for initialization
    void Start()
        {
        SelectWeapon();

        }

        // Update is called once per frame
        void Update()
        {
        
            int previousWeaponSelected = selectedWeapon;

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (selectedWeapon >= transform.childCount - 1)
                    selectedWeapon = 0;
                else
                    selectedWeapon++;

            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (selectedWeapon <= transform.childCount - 1)
                    selectedWeapon = 0;
                else
                    selectedWeapon++;

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




