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

    private Animator animator;

    public static int ammoGun;        //Ammo of the gun
    public static int ammoBomb;       //Ammo of the bomb

    [SerializeField]
    float damper;
    [SerializeField]
    bool start;

    private int weaponType = 0;
    public int WeaponType
    {
        set { weaponType = value; }
    }

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
    }    

    void Update()
    {

        //Fires the gun
        if (weaponEquiped && Input.GetMouseButtonDown(0) && activeWeapon != 3)
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

        Debug.Log(weaponSlots[0] + ",  "+weaponSlots[1] + ",  "+weaponSlots[2] + ",  ");
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

    void Recoil()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        Transform player = GameObject.Find("Player").transform;
        Debug.Log(player);
        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        Vector2 newpos = (playerPos - mousePos2D);
        newpos.Normalize();
        player.position += new Vector3(newpos.x / damper, newpos.y / damper, 0);
    }

    void BombAim()
    {
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint()
    }

    void SwordBehaviour(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            animator.SetTrigger("playerSlash");
        }

        if(other.tag == "Wall")
        {
            animator.SetTrigger("playerChop");

        }
    }
}
