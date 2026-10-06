//爆弾を投げる
using UnityEngine;
public class BombThrow : MonoBehaviour
{
    [SerializeField] PlayerRotation playerR;//PlayerRotationクラス
    private bool moving = false;//動いているか判定
    private float speed = 5f; // 移動速度
    private float moveX = 10;//移動方向X
    private float moveY = 0;//移動方向Y
    private int direction = 0;//プレイヤーの向き
    void Update()
    {
        //動いていい時
        if (moving == true)
        {
            //爆弾を動かす
            transform.position += new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
        }
    }
    //投げる
    public void Throw()
    {
        //動くことを許可する
        moving = true;
        //プレイヤーの向きをplayerRに聞く
        direction = playerR.handover();
        //プレイヤーの向きに合わせて爆弾の移動方向を決める
        switch (direction)
        {
            case 1: // 上
                moveX = 0;
                moveY = 10;
                break;
            case 2: // 左
                moveX = -10;
                moveY = 0;
                break;
            case 3: // 下
                moveX = 0;
                moveY = -10;
                break;
            case 4: // 右
                moveX = 10;
                moveY = 0;
                break;
        }
    }
    //動いているかを教える
    public bool handover()
    {
        //動いているかを返す
        return moving;
    }
}
