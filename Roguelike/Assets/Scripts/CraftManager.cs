using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftManager : MonoBehaviour {

    [SerializeField]
    private Transform[] slots;
    private bool openUI;
    private bool crafted;

	// Use this for initialization
	void Start () {
        slots = new Transform[2];
        slots[0] = transform.GetChild(1).GetChild(0);
        slots[1] = transform.GetChild(1).GetChild(1);
    }
	
	// Update is called once per frame
	void Update () {
		if(slots[0].childCount > 0 && slots[1].childCount > 0 && !crafted)
        {
            Craft(slots[0].GetChild(0).name, slots[1].GetChild(0).name);
        }
        if ((slots[0].childCount > 0 && slots[1].childCount == 0) || (slots[1].childCount > 0 && slots[0].childCount == 0))
        {
            openUI = true;
            crafted = false;
        }
        if (slots[0].childCount == 0 && slots[1].childCount == 0 && openUI)
        {
            openUI = false;
            gameObject.SetActive(false);
        }
    }

    void Craft(string objectOne, string objectTwo)
    {
        crafted = true;

        if (objectOne == "GunPowder(Clone)" || objectTwo == "GunPowder(Clone)")
        {
            if (objectOne == "Stone(Clone)" || objectTwo == "Stone(Clone)")
            {
                Debug.Log("craft gun");
            }
            else if (objectOne == "Wood(Clone)" || objectTwo == "Wood(Clone)")
            {
                Debug.Log("craft bomb");
            }
        }
        else if (objectOne == "Stone(Clone)" || objectTwo == "Stone(Clone)")
        {
            if (objectOne == "Wood(Clone)" || objectTwo == "Wood(Clone)")
            {
                Debug.Log("craft sword");
            }

        }
    }
}
