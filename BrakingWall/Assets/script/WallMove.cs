using UnityEngine;

public class wallMove : MonoBehaviour
{
    [SerializeField] private float wallmovespeed = 0.5f; // 壁の移動速度
    private float wallpositionX; // 壁のX軸
    private float wallpositionY; // 壁のY軸

    void Start()
    {
        wallpositionX = gameObject.transform.position.x;
        wallpositionY = gameObject.transform.position.y;
    }
    void Update()
    {
        wallpositionX = wallpositionX + wallmovespeed * Time.fixedDeltaTime;
        gameObject.transform.position = new Vector3(wallpositionX, wallpositionY); // カメラの位置をプレイヤーの位置に合わせる
    }
    public float handover()
    {
        //動いているかを返す
        return wallpositionX;
    }
}
