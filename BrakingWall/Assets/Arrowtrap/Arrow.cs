using UnityEngine;

public class Arrow : MonoBehaviour

{
    [Header("Arrow")]
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform spawnPoint;

    [Header("Settings")]
    [SerializeField] private float interval = 0.5f;
    [SerializeField] private bool autoStart = true;

    private float timer;
    private bool isActive;

    private void Start()
    {
        isActive = autoStart;
    }

    private void Update()
    {
        if (!isActive)
            return;

        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;
            Fire();
        }
    }

    private void Fire()
    {
        Instantiate(
            arrowPrefab,
            spawnPoint.position,
            spawnPoint.rotation
        );
    }

    public void StartTrap()
    {
        isActive = true;
        timer = 0f;
    }

    public void StopTrap()
    {
        isActive = false;
    }
}


