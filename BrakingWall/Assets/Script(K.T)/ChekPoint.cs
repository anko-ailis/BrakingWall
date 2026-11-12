using UnityEngine;

public class ChekPoint : MonoBehaviour
{
    //プレイヤー側につける。引数でGameManegerに位置座標を渡してリスタートさせたい
    private Vector3 SpawnPoint;
    private Vector3 Vector3;
    //public Transform Point 
    //{
    //    get { return ; }
    //    set { Point = TransformPoint(SpawnPoint.Position) ;}
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.transform.CompareTag("ChekPoint"))
            {
                Debug.Log(collision.transform.position);
                SpawnPoint = collision.transform.position;
            }
        }

    }

}
