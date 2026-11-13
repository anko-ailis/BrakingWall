using UnityEngine;
using System.Collections;

public class ChekPoint : MonoBehaviour
{
    //プレイヤー側につける。引数でGameManegerに位置座標を渡してリスタートさせたい
    private Vector3 SpawnPoint;
    private Transform traSpawn;
    public Transform TraPoint
    {
        get { return traSpawn; }//transform.TransformPoint
    }
    public Vector3 VecSpawnPoint
    {
        get { return SpawnPoint; }
    }

    private void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject play in enemies)
        {
            traSpawn = play.transform;
            SpawnPoint = play.transform.position;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.transform.CompareTag("player"))
            {
                //Debug.Log(collision.transform.position);
                Transform coll = collision.transform;
                traSpawn = coll.transform;
                Vector2 center2D = coll.transform.position;
                SpawnPoint = new Vector3(center2D.x, center2D.y, 0f);
                Debug.Log(SpawnPoint);
                //SpawnPoint = new Vector3(collision.gameObject);
            }
        }

    }

}
