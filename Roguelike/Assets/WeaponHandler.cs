using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHandler : MonoBehaviour {

    Color baseColor;
    [SerializeField]
    Color selectedColor;

    bool leftActive;
    bool rightActive;

    // Use this for initialization
    void Start () {
        baseColor = transform.GetChild(0).GetComponent<Image>().color;
    }
	
	// Update is called once per frame
	void Update () {
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SetWeapon(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetWeapon(false);
        }
    }

    void SetWeapon(bool left)
    {
        Transform leftSlot = transform.GetChild(0);
        Transform rightSlot = transform.GetChild(1);

        if (left)
        {
            if (leftSlot.childCount > 0)
            {
                leftSlot.GetComponent<Image>().color = selectedColor;
                rightSlot.GetComponent<Image>().color = baseColor;
                leftSlot.GetChild(0).GetComponent<WeaponScript>().enabled = true;

                if(rightSlot.childCount > 0)
                    rightSlot.GetChild(0).GetComponent<WeaponScript>().enabled = false;
            }
        }
        else
        {
            if (transform.GetChild(1).childCount > 0)
            {
                rightSlot.GetComponent<Image>().color = selectedColor;
                leftSlot.GetComponent<Image>().color = baseColor;
                rightSlot.GetChild(0).GetComponent<WeaponScript>().enabled = true;

                if (rightSlot.childCount > 0)
                    leftSlot.GetChild(0).GetComponent<WeaponScript>().enabled = false;
            }
        }
    }
}
