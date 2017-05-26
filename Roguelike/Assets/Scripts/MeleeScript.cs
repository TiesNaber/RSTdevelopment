using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{

    public bool canHitEnemy;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision  " + other.name);
        if (other.tag == "Enemy")
        {
            canHitEnemy = true;
        }
       
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            canHitEnemy = false;
        }
    }
}
