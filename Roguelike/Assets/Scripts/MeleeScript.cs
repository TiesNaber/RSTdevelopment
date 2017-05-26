using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class MeleeScript : MonoBehaviour
    {

        public bool canHitEnemy;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnTriggerStay2D(Collider2D other)
        {
            Debug.Log("collision  " + other.name);
            if (other.tag == "Enemy" && Input.GetMouseButtonDown(0))
            {
                canHitEnemy = true;
                other.GetComponent<EnemyHealth>().ChangeEnemyHealth = 30;
            }

        }
    }
