using UnityEngine;

public class Arrowamo : MonoBehaviour
{

    [SerializeField] private float Speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private float ArrowRotat;

    private void Start()
    {
        if (Speed < 1&& Speed > -1) Speed = 10;
        if (lifeTime < 2) lifeTime = 2;
        this.transform.Rotate(0,0,ArrowRotat);
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        this.transform.Translate(0,Speed * Time.deltaTime, 0);
        
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    //private void OnTriggerEnter(Collider other)
    //{
        
    //}
}


