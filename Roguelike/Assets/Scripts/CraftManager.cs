using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour {

    [SerializeField]
    private Transform[] slots;
    private Transform craftedSlot;
    private Transform weaponSlots;
    private bool openUI;
    private bool crafted;

	// Use this for initialization
	void Start () {
        slots = new Transform[2];
        slots[0] = transform.GetChild(0).GetChild(0);
        slots[1] = transform.GetChild(0).GetChild(1);
        craftedSlot = transform.GetChild(1);
        weaponSlots = transform.root.GetChild(4);
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
            crafted = false;
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
                GameObject weapon = (GameObject)Instantiate(Resources.Load("Gun"), craftedSlot);
                weapon.GetComponent<Button>().onClick.AddListener((delegate { OnCrafted(); }));
            }
            else if (objectOne == "Wood(Clone)" || objectTwo == "Wood(Clone)")
            {
                GameObject weapon = (GameObject)Instantiate(Resources.Load("Bomb"), craftedSlot);
                weapon.GetComponent<Button>().onClick.AddListener((delegate { OnCrafted(); }));
            }
        }
        else if (objectOne == "Stone(Clone)" || objectTwo == "Stone(Clone)")
        {
            if (objectOne == "Wood(Clone)" || objectTwo == "Wood(Clone)")
            {
                GameObject weapon = (GameObject)Instantiate(Resources.Load("Sword"), craftedSlot);
                weapon.GetComponent<Button>().onClick.AddListener((delegate { OnCrafted(); }));
            }

        }
    }

    public void OnCrafted()
    {
        Destroy(slots[0].GetChild(0).gameObject);
        Destroy(slots[1].GetChild(0).gameObject);
        craftedSlot.GetChild(0).GetComponent<WeaponScript>().Crafted = true;
        craftedSlot.GetChild(0).GetComponent<WeaponScript>().AttackAmount = (int)Random.Range(1, 4);
        craftedSlot.GetChild(0).SetParent(GetFreeSlot());
        crafted = false;
        openUI = false;
        gameObject.SetActive(false);
    }

    Transform GetFreeSlot()
    {
        for (int i = 0; i < weaponSlots.childCount; i++)
        {
            if(weaponSlots.GetChild(i).childCount == 0)
            {
                return weaponSlots.GetChild(i);
            }
        }

        return null;
    }
}
