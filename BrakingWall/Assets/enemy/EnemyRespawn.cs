using UnityEngine;
using System.Collections;
using System.Threading;

public class EnemyRespawn : MonoBehaviour
{

    [SerializeField] public GameObject dummyEnemyPrefab;
    [SerializeField] public Transform firePoint;

    public float speed = 10f;
    public float spawnTime = 2f;

    private float timer;


    //// ƒŠƒXƒ|[ƒ“‚Ü‚Å‚ÌŠÔ
    //public float respawnTime = 3f;

    //// “G‚ÌÅ‰‚ÌˆÊ’u
    //private Vector3 startPosition;

    ////// “G‚ÌÅ‰‚Ì‰ñ“]
    ////private Quaternion startRotation;

    ////// Rigidbody2D
    ////private Rigidbody2D rb;

    ////// •œŠˆ’†‚©‚Ç‚¤‚©
    ////private bool isRespawning = false;

    //void Start()
    //{
    //    // Å‰‚ÌˆÊ’u‚ğ•Û‘¶
    //    startPosition = transform.position;

    //    // Å‰‚Ì‰ñ“]‚ğ•Û‘¶
    //    startRotation = transform.rotation;

    //    // Rigidbody2D‚ğæ“¾
    //    rb = GetComponent<Rigidbody2D>();
    //}

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            Respawn();
            timer = 0f;
        }
        //Respawn();
    }
    // “G‚ª‚¢‚È‚­‚È‚Á‚½‚Æ‚«‚ÉŒÄ‚Ño‚·
    public void Respawn()
    {
        GameObject dummyenemy = Instantiate(
          dummyEnemyPrefab,
          firePoint.position,
          firePoint.rotation
      );

        Rigidbody2D rb = dummyenemy.GetComponent<Rigidbody2D>();


        rb.gravityScale = 0;
        //rb.linearVelocity = Vector2.right * speed;
    }

    //IEnumerator RespawnCoroutine()
    //{
    //    // 3•b‘Ò‚Â
    //    yield return new WaitForSeconds(respawnTime);

    //    // Œ³‚ÌˆÊ’u‚É–ß‚·
    //    transform.position = startPosition;

    //    // Œ³‚Ì‰ñ“]‚É–ß‚·
    //    transform.rotation = startRotation;

    //    // ‘¬“x‚ğƒŠƒZƒbƒg
    //    if (rb != null)
    //    {
    //        rb.linearVelocity = Vector2.zero;
    //        rb.angularVelocity = 0f;
    //    }

    //    // “G‚ğ•œŠˆ‚³‚¹‚é
    //    gameObject.SetActive(true);

    //    isRespawning = false;
    //}
}




