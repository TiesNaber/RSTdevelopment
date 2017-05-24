using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    //the object that you shoot
    public GameObject[] weapons;
    //the rotation point from where to shoot.
    public Transform aimPoint;

    // Use this for initialization
    void Start()
    {

    }    
    
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0) /*&& Time.time > timeToFire*/)
        {
            /*timeToFire = Time.time + fireRate;*/
            //Lose 1 ammo.
            Instantiate(weapons[0], aimPoint.position, aimPoint.rotation);
        }
        else
        {
            Debug.Log("No Ammo");
        }
    }
}
