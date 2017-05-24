using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WeaponHandler : MonoBehaviour {

    [SerializeField]
    Color baseColor;
    [SerializeField]
    Color selectedColor;

    bool leftActive;
    bool rightActive;

    public WeaponScript weaponScript;

    // Use this for initialization
    void Start () {
        baseColor = transform.GetChild(0).GetComponent<Image>().color;
        weaponScript = GameObject.Find("Player").GetComponent<WeaponScript>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if(!weaponScript)
            weaponScript = GameObject.Find("Player").GetComponent<WeaponScript>();

        if (Input.mouseScrollDelta.y > 0)
        {
            SetWeapon(true);
        }
        else if(Input.mouseScrollDelta.y < 0)
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

                //Equip weapon
                if (leftSlot.childCount > 0)
                    weaponScript.SetWeaponActive(leftSlot.GetChild(0).name);
                else
                    Debug.Log("something went wrong");
            }
        }
        else
        {
            if (transform.GetChild(1).childCount > 0)
            {
                rightSlot.GetComponent<Image>().color = selectedColor;
                leftSlot.GetComponent<Image>().color = baseColor;

                if (rightSlot.childCount > 0)
                    weaponScript.SetWeaponActive(rightSlot.GetChild(0).name);
                else
                    Debug.Log("something went wrong");
            }
        }
    }

    public void ResetValues()
    {
        Transform leftSlot = transform.GetChild(0);
        Transform rightSlot = transform.GetChild(1);

        rightSlot.GetComponent<Image>().color = baseColor;
        leftSlot.GetComponent<Image>().color = baseColor;
    }
}
