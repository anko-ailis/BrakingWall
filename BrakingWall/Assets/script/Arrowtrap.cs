using UnityEngine;

public class Arrowtrap : MonoBehaviour
{


    public GameObject arrowPrefab;
    public Transform firePoint;

    public float speed = 10f;
    public float spawnTime = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        GameObject arrow = Instantiate(
            arrowPrefab,
            firePoint.position,
            firePoint.rotation
        );

        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();

        rb.gravityScale = 0;
        rb.linearVelocity = Vector2.right * speed;
    }
}



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

