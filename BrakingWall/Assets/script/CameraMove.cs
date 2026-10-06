using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject player; // プレイヤーのオブジェクト
    void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10); // カメラの位置をプレイヤーの位置に合わせる
    }
}
