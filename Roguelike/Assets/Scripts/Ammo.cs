using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour
{
    public float speed;
    public int damage = 10;
    private int? type;
    public int Type
    {
        set { type = value; }
    }

    Vector3 startPos;
    Vector3 endPos;
    public Vector3 EndPos
    {
        set { endPos = value; }
    }
    Vector3 bending = Vector3.up;
    float travelTime = 0.8f;
    float timeStamp;

    [SerializeField]
    GameObject explosion;


    void Start()
    {
        startPos = transform.position;
        timeStamp = Time.time;
    }

    void Update()
    {
        if (type == 0)
            BombBehavior();
        else if (type == 1)
            BulletBehavior();
    }

    void BulletBehavior()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    void BombBehavior()
    {
        Vector3 currentPos = Vector3.Lerp(startPos, endPos, (Time.time - timeStamp) / travelTime);

        currentPos.x += bending.x * Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp) / travelTime) * Mathf.PI);
        currentPos.y += bending.y * Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp) / travelTime) * Mathf.PI);
        currentPos.z = 0;

        transform.position = currentPos;

        if ((endPos.x - transform.position.x < 0.1f && endPos.y - transform.position.y < 0.1f) && (endPos.x - transform.position.x > -0.1f && endPos.y - transform.position.y > -0.1f)) 
        {
            GameObject explode = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);
            Camera.main.GetComponent<CameraFollow2DPlatformer>().ShakeMe = 1;
            Destroy(explode, 3);
            Destroy(gameObject, 0.01f);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision  " + other.name);
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().ChangeEnemyHealth = damage;
            Destroy(gameObject);
        }

        else if (other.tag == "Wall") 
        {
            Debug.Log("destroy Bullet");
            Destroy(gameObject);
        }        
    }
}