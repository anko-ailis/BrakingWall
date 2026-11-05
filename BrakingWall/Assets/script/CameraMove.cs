using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject player; // プレイヤーのオブジェクト
    [SerializeField] private float cameramoveSpeed = 0.5f;// カメラの移動速度
    [SerializeField] private float camerapositionlimitup = 5; // カメラのY軸の上限
    [SerializeField] private float camerapositionlimitdown = -5; // カメラのY軸の下限
    private float camerapositionX; // カメラのX軸
    private float camerapositionY; // カメラのY軸

    void Start()
    {
        camerapositionX = gameObject.transform.position.x;
    }
    void Update()
    {
        if (player.transform.position.y > camerapositionlimitup)
        {
            camerapositionY = camerapositionlimitup;
        }
        else if (player.transform.position.y < camerapositionlimitdown)
        {
            camerapositionY = camerapositionlimitdown;
        }
        else
        {
            camerapositionY = player.transform.position.y;
        }
        camerapositionX = camerapositionX + cameramoveSpeed * Time.fixedDeltaTime;
        gameObject.transform.position = new Vector3(camerapositionX, camerapositionY, -10); // カメラの位置をプレイヤーの位置に合わせる
    }
}
