using System.Collections;
using System.Collections.Generic;
using Completed;
using UnityEngine;

    public class MeleeScript : MonoBehaviour
    {

        public bool canHitEnemy;
        private Animator animator;                  //Used to store a reference to the Player's animator component.
        private AudioSource audioSource;


        // Use this for initialization
        void Start()
        {
            animator = GameObject.Find("Player").GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
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
                animator.SetTrigger("playerSlash");
                audioSource.Play();
            }
        }
}
