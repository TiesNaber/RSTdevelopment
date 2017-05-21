using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    private bool crafted;
    public bool Crafted
    {
        set { crafted = value; }
    }

    private int attackAmount;
    public int AttackAmount
    {
        set { attackAmount = value; }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    Debug.Log("ATTACK!");
                }
            }
            else
            {
                Debug.Log("No hit");
            }
        }
    }
}
