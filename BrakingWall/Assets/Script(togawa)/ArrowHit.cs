using UnityEngine;

public class ArrowHit : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("矢にあたった！");

        if (other.CompareTag("Player"))
        {
            Debug.Log("プレイヤーに命中！");

            PlayerHealth health = other.GetComponent<PlayerHealth>();
            
        }
            Destroy(gameObject);
    }

}




