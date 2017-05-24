using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    //the object that you shoot
    public GameObject[] weapons;
    //the rotation point from where to shoot.
    public Transform aimPoint;
    [SerializeField]
    float damper;

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
            Recoil();
        }
        else
        {
            Debug.Log("No Ammo");
        }
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
}
