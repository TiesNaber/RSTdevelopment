using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    //the object that you shoot
    public GameObject[] bullets;
    //the rotation point from where to shoot.
    public Transform aimPoint;
    //Weapon Slots, used to activate or deactivate when you switch weapon (gun/bomb)
    public GameObject[] weaponSlots;//1 = bomb, 2= gun, 3 = sword
    
    //Reference for the weapon that is active
    private int activeWeapon;
    //Bool to check if there is a weaponEquiped
    private bool weaponEquiped;

    public static int ammoGun;        //Ammo of the gun
    public static int ammoBomb;       //Ammo of the bomb

    // Use this for initialization
    void Start()
    {

    }    

    void Update()
    {
        //Fires the gun
        if (weaponEquiped == true && Input.GetMouseButtonDown(0) && activeWeapon != 3)
        {           
            Instantiate(bullets[activeWeapon], aimPoint.position, aimPoint.rotation);
            DeactivateWeapon();
        }
        else
        {
            return;
        }
        
    }

    public void SetWeaponActive(string weaponName)
    {

        weaponEquiped = true;

        Debug.Log("test");
        if (weaponName == "Bomb(Clone)")
        {
            weaponSlots[0].SetActive(true);
            weaponSlots[1].SetActive(false);
            weaponSlots[2].SetActive(false);

            activeWeapon = 0;

            Debug.Log("Equip Bomb");
        }
        if (weaponName == "Gun(Clone)")
        {
            weaponSlots[0].SetActive(false);
            weaponSlots[1].SetActive(true);
            weaponSlots[2].SetActive(false);

            activeWeapon = 1;
            Debug.Log("Equip Gun");
        }
        if (weaponName == "Sword(Clone)")
        {
            weaponSlots[0].SetActive(false);
            weaponSlots[1].SetActive(false);
            weaponSlots[2].SetActive(true);

            activeWeapon = 2;
            Debug.Log("Equip Sword");
        }
    }

    public void DeactivateWeapon()
    {
        weaponEquiped = false;                
        
        weaponSlots[0].SetActive(false);
        weaponSlots[1].SetActive(false);
        weaponSlots[2].SetActive(false);
        
    }
}
