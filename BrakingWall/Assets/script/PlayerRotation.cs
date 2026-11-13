//プレイヤーを移動方向に合わせて回転させる
using UnityEngine;
using UnityEngine.InputSystem;
//向き
public enum Direction
{
    Up = 1,//上
    Left = 2,//左
    Down = 3,//下
    Right = 4//右
}
public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private GameObject player;//プレイヤーのオブジェクト
    private GameObject holdbomb;//掴んでいる爆弾のオブジェクト
    private int direction = 3;//プレイヤーの向き（初期値は下）
    private bool hold = false;//爆弾を掴んでいるか判定
    //プレイヤーの向きを上に補正させる
    private void RotaUp()
    {
        //プレイヤーの向きが上の時
        if (direction == (int)Direction.Up)
        {

        }
        //プレイヤーの向きが左の時
        else if (direction == (int)Direction.Left)
        {
            player.transform.Rotate(0, 0, -90);
        }
        //プレイヤーの向きが下の時
        else if (direction == (int)Direction.Down)
        {
            player.transform.Rotate(0, 0, 180);
        }
        //プレイヤーの向きが右の時
        else if (direction == (int)Direction.Right)
        {
            player.transform.Rotate(0, 0, 90);
        }
    }
    //Wキーが押された時
    public void RotaW(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RotaUp(); //プレイヤーの向きを上に補正
            BrotaW();
            direction = 1;//プレイヤーの向きは上
        }
    }
    //Aキーが押された時
    public void RotaA(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RotaUp();//プレイヤーの向きを上に補正
            player.transform.Rotate(0, 0, 90);//プレイヤーを左に回転
            BrotaA();
            direction = 2;//プレイヤーの向きは左
        }
        
    }
    //Sキーが押された時
    public void RotaS(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RotaUp();//プレイヤーの向きを上に補正
            player.transform.Rotate(0, 0, 180);//プレイヤーを下に回転
            BrotaS();
            direction = 3;//プレイヤーの向きは下   
        }
    }
    //Dキーが押された時
    public void RotaD(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RotaUp();//プレイヤーの向きを上に補正
            player.transform.Rotate(0, 0, -90);//プレイヤーを右に回転
            BrotaD();
            direction = 4;//プレイヤーの向きは右      
        }
    }
    //プレイヤーの向きを教える
    public int directionhandover()
    {
        //プレイヤーの向きを返す
        return direction;
    }
    //爆弾を持っているかを教えてもらう
    public void Holdbombhandover(bool newhold)
    {
        hold = newhold;
    }
    //持っている爆弾の名前を教えてもらう
    public void Holdbombnamehandover(GameObject newbonb)
    {
        holdbomb = newbonb;
    }
    private void BrotaUp()
    {
        //プレイヤーの向きが上の時
        if (direction == (int)Direction.Up)
        {

        }
        //プレイヤーの向きが左の時
        else if (direction == (int)Direction.Left)
        {
            holdbomb.transform.Rotate(0, 0, -90);
        }
        //プレイヤーの向きが下の時
        else if (direction == (int)Direction.Down)
        {
            holdbomb.transform.Rotate(0, 0, 180);
        }
        //プレイヤーの向きが右の時
        else if (direction == (int)Direction.Right)
        {
            holdbomb.transform.Rotate(0, 0, 90);
        }
    }
    private void BrotaW()
    {
        if (hold == true)
        {
            BrotaUp();//爆弾の向きを上に補正
            holdbomb.transform.Rotate(0, 0, 0);//爆弾を上に回転
        }
    }
    private void BrotaA()
    {
        if (hold == true)
        {
            BrotaUp();//爆弾の向きを上に補正
            holdbomb.transform.Rotate(0, 0, 90);//爆弾を左に回転
        }
    }
    private void BrotaS()
    {
        if (hold == true)
        {
            BrotaUp();//爆弾の向きを上に補正
            holdbomb.transform.Rotate(0, 0, 180);//爆弾を下に回転
        }
    }
    private void BrotaD()
    {
        if (hold == true)
        {
            BrotaUp();//爆弾の向きを上に補正
            holdbomb.transform.Rotate(0, 0, -90);//爆弾を右に回転
        }
    }

}
