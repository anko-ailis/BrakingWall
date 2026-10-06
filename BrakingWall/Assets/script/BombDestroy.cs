//爆弾が投げられたときに壁に当たると爆発する（消える）
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    [SerializeField] BombThrow bombT;//BombThrowクラス
    private bool moving = false;//動いているか判定
    //当たった時の処理
    void OnCollisionEnter2D(Collision2D collision)
    {
        //動いているかbombTに聞く
        moving = bombT.handover();
        //動いている時
        if (moving == true)
        {
            Debug.Log(collision.gameObject);
            //当たったオブジェクトが壁の時
            if (collision.gameObject.CompareTag("wall"))
            {
                //爆弾を消す
                Destroy(gameObject);
            }
        }
    }
}
