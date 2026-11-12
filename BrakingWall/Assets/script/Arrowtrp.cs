using UnityEngine;

public class Arrowtrp : MonoBehaviour
{

    public GameObject projectile;

    public Transform spawnLocation;                       

    public float spawnTime = 5f;

    private float timeSinceSpawned = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawned += Time.deltaTime;
        if(timeSinceSpawned >= spawnTime)
        {
            Instantiate(projectile, spawnLocation.position, spawnLocation.rotation);
            
        }

        timeSinceSpawned = 0;
        Instantiate(projectile, spawnLocation.position,spawnLocation.rotation);
    }
}
