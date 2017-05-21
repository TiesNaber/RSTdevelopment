using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour {

    public bool isCrafted;
    Transform weaponSlots;
	// Use this for initialization
	void Start () {
        weaponSlots = transform.root.GetChild(2);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void OnClick()
    {
        if(!isCrafted)
        {
            Debug.Log("weapon crafted");
            foreach (Transform childSlot in weaponSlots)
            {
                if(childSlot.childCount == 0)
                {
                    
                    transform.SetParent(childSlot);
                    isCrafted = true;
                    return;
                }
            }
        }
    }
}
