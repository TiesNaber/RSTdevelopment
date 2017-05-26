﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombKill : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "enemy")
        {
            col.GetComponent<EnemyHealth>().ChangeEnemyHealth = 100;
        }
    }
}
