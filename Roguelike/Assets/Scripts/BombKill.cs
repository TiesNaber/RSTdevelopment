using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed
{
    public class BombKill : MonoBehaviour {

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Enemy")
            {
                col.GetComponent<EnemyHealth>().ChangeEnemyHealth = 100;
            }
            if(col.tag == "Player")
            {
                col.GetComponent<Player>().LoseFood(50);
                col.GetComponent<VisualDamage>().MakeItBlink(true, false);
            }
            if(col.tag == "Wall")
            {
                col.GetComponent<Wall>().DamageWall(5);
            }
        }
    }
}
