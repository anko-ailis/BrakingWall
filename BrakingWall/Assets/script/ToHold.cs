//物を掴む
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToHold : MonoBehaviour
{
    [SerializeField] SliderExample se;//SliderExampleクラス
    [SerializeField] BombThrow bombT;//BombThrowクラス
    [SerializeField] UIChange ui; //UIChangeクラス
    [SerializeField] private Transform grabPoint;//掴む位置
    [SerializeField] private Transform rayPoint;//Rayの発射位置

    private float rayDistance = 0.5f;//Rayの距離
    private bool hold = false;//掴んでいるか判定
    private bool thereissutamina = false;//スタミナが足りているか判定
    private GameObject bomb;//掴んでいる爆弾
    RaycastHit2D hit;//Rayの当たり判定

    void Update()
    {
        //掴んでいい時
        if (hold == true)
        {
            //爆弾が存在しているとき
            if (bomb != null)
            {
                //運ぶ
                Hold();
            }
            else
            {
                //掴んでいない状態にする
                hold = false;
                ui.ChangeImage2();
            }

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
            //入力の状態が始まった時
            if (context.started)
            {
                //掴んでいない時
                if (hold == false)
                {
                    thereissutamina = se.IsStaminaAvailable();
                    if (thereissutamina == true)
                    {
                        Debug.Log("スタミナが足りるよん");
                        //掴む爆弾を取得
                        bomb = hit.collider.gameObject;
                        //掴んでいる状態にする
                        hold = true;
                        ui.ChangeImage1();
                    }
                    else
                    {
                        Debug.Log("スタミナが足りないよん");
                        //スタミナが足りない時の処理（必要に応じて追加）
                    }
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
                    ui.ChangeImage2();
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