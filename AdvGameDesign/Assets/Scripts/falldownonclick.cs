using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class falldownonclick : MonoBehaviour {

    Animator anime;

    public static int monies;
    private int count;
    public Text moniesText;

	// Use this for initialization
	void Start () {
        anime = gameObject.GetComponent<Animator>();
        monies = 0;
        moniesText.text = "Money: " + monies.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1"))
        {
            anime.SetBool("FallDown", true);
            if (count < 1)
            {
                monies = monies + 10;
                count += 1;
            }
            moniesText.text = "Money: " + monies.ToString();
        }
        else
        {
            anime.SetBool("FallDown", false);
            count = 0;
        }

	}
}
