using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour
{
    public float speed;
    public int damage = 10;


    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);        
    }

    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.tag == "Enemy")
        {            
            //other.GetComponent<EnemyHealth>().EnemyTakeDamage(damage);
            Destroy(gameObject);
        }

        else if (other.tag == "Wall") 
        {
            Destroy(gameObject);
        }        
    }
}