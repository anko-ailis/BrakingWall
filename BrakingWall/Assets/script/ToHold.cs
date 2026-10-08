//物を掴む
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToHold : MonoBehaviour
{
    [SerializeField] BombThrow bombT;//BombThrowクラス
    [SerializeField] private Transform grabPoint;//掴む位置
    [SerializeField] private Transform rayPoint;//Rayの発射位置

    private float rayDistance = 0.2f;//Rayの距離
    private bool hold = false;//掴んでいるか判定
    private GameObject bomb;//掴んでいる爆弾
    RaycastHit2D hit;//Rayの当たり判定

    void Update()
    {
        //掴んでいい時
        if (hold == true)
        {
            //運ぶ
            Hold();
        }
       
    }
    //Rayを飛ばして爆弾を掴む
    public void Ray(InputAction.CallbackContext context)
    {
        //Rayを飛ばす
        hit = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);
        //Rayが当たって当たったオブジェクトのタグが爆弾だった時
        if (hit.collider != null && hit.collider.tag == "bomb")
        {
            //掴む爆弾を取得
            bomb = hit.collider.gameObject;
            //入力の状態が始まった時
            if (context.started)
            {
                //掴んでいない時
                if (hold == false)
                {
                    //掴んでいる状態にする
                    hold = true;
                }
                //掴んでいる時
                else
                {
                    //掴む爆弾のBombThrowクラスを取得
                    bombT = bomb.GetComponent<BombThrow>();
                    //掴んでいる爆弾を投げる
                    bombT.Throw();
                    //掴んでいる状態を解除
                    hold = false;
                }
            }
        }
    }
    //運ぶ
    void Hold()
    {
        //掴んでいる爆弾の位置を掴む位置に合わせる
        bomb.transform.position = grabPoint.position;
    }
}