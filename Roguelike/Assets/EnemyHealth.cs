using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    private int enemyHealth = 40;
    public int ChangeEnemyHealth
    {
        set
        {
            enemyHealth -= value;
            if(enemyHealth <= 0)
                GetComponent<VisualDamage>().MakeItBlink(false, false);
            else
                GetComponent<VisualDamage>().MakeItBlink(false, true);

        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
