using UnityEngine;

public class ArrowDamage : MonoBehaviour
{
    



    public int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        PlayerHealth player =
            collision.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}

  

