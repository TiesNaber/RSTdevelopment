using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    //the object that you shoot
    public GameObject[] projectiles;
    //the rotation point from where to shoot.
    public Transform aimPoint;
    //Weapon Slots, used to activate or deactivate when you switch weapon (gun/bomb)
    public GameObject[] weaponSlots;//1 = bomb, 2= gun, 3 = sword
    
    //Reference for the weapon that is active
    private int activeWeapon;
    //Bool to check if there is a weaponEquiped
    private bool weaponEquiped;

    private Animator animator;

    int ammoGun;        //Ammo of the gun

    [SerializeField]
    float damper;
    [SerializeField]
    bool start;

    Vector3 mousePos;

    private int weaponType = 0;
    public int WeaponType
    {
        set { weaponType = value; }
    }

    WeaponHandler weaponHandler;
    GameObject selectedWeapon;

    // Use this for initialization
    void Start()
    {
        weaponSlots[0] = transform.GetChild(2).gameObject;
        weaponSlots[1] = transform.GetChild(3).gameObject;
        weaponSlots[2] = transform.GetChild(4).gameObject;

        weaponSlots[0].SetActive(false);
        weaponSlots[1].SetActive(false);
        weaponSlots[2].SetActive(false);

        weaponEquiped = false;
        if(!start)
            GameObject.Find("Weapons").GetComponent<WeaponHandler>().ResetValues();

        if (!weaponHandler)
            weaponHandler = GameObject.Find("Weapons").GetComponent<WeaponHandler>();
    }    

    void Update()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x < transform.position.x && weaponEquiped)
            GetComponent<PlayerFlip>().FaceRight = false;
        else if (mousePos.x > transform.position.x && weaponEquiped)
            GetComponent<PlayerFlip>().FaceRight = true;

        //Fires the gun
        if (weaponEquiped && Input.GetMouseButtonDown(0) && activeWeapon != 2)
        {
            if (activeWeapon == 1)
                Recoil();
            GameObject temp = (GameObject)Instantiate(projectiles[activeWeapon], aimPoint.position, aimPoint.rotation);
            temp.GetComponent<Ammo>().EndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            temp.GetComponent<Ammo>().Type = activeWeapon;
            DeactivateWeapon();
        }
        else
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
            }
        }

        
    }

    public void SetWeaponActive(Transform weapon)
    {

        weaponEquiped = true;

        Debug.Log(weaponSlots[0] + ",  "+weaponSlots[1] + ",  "+weaponSlots[2] + ",  ");
        if (weapon.name == "Bomb(Clone)")
        {
            weaponSlots[0].SetActive(true);
            weaponSlots[1].SetActive(false);
            weaponSlots[2].SetActive(false);

            activeWeapon = 0;

            Debug.Log("Equip Bomb");
        }
        if (weapon.name == "Gun(Clone)")
        {
            weaponSlots[0].SetActive(false);
            weaponSlots[1].SetActive(true);
            weaponSlots[2].SetActive(false);

            activeWeapon = 1;
            Debug.Log("Equip Gun");

            
        }
        if (weapon.name == "Sword(Clone)")
        {
            weaponSlots[0].SetActive(false);
            weaponSlots[1].SetActive(false);
            weaponSlots[2].SetActive(true);

            activeWeapon = 2;
            Debug.Log("Equip Sword");
        }

        if (weapon == weaponHandler.transform.GetChild(0))
            selectedWeapon = weapon.gameObject;
        else
            selectedWeapon = weapon.gameObject;
    }

    public void DeactivateWeapon()
    {
        weaponEquiped = false;

        weaponSlots[0].SetActive(false);
        weaponSlots[1].SetActive(false);
        weaponSlots[2].SetActive(false);

        Destroy(selectedWeapon);
    }

    void Recoil()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        Transform player = GameObject.Find("Player").transform;
        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        Vector2 newpos = (playerPos - mousePos2D);
        newpos.Normalize();
        player.position += new Vector3(newpos.x / damper, newpos.y / damper, 0);
    }
}
