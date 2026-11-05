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
    private int direction = 1;//プレイヤーの向き（初期値は上）
    //プレイヤーの向きを上に補正させる
    private void RotaUp()
    {
        //向きが上の時
        if (direction == (int)Direction.Up)
        {

        }
        //向きが左の時
        else if (direction == (int)Direction.Left)
        {
            player.transform.Rotate(0, 0, -90);
        }
        //向きが下の時
        else if (direction == (int)Direction.Down)
        {
            player.transform.Rotate(0, 0, 180);
        }
        //向きが右の時
        else if (direction == (int)Direction.Right)
        {
            player.transform.Rotate(0, 0, 90);
        }
    }
    //Wキーが押された時
    public void RoteW(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RotaUp(); //向きを上に補正
            direction = 1;//向きは上
        }
    }
    //Aキーが押された時
    public void RoteA(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RotaUp();//向きを上に補正
            player.transform.Rotate(0, 0, 90);//プレイヤーを左に回転
            direction = 2;//向きは左
        }
        
    }
    //Sキーが押された時
    public void RoteS(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RotaUp();//向きを上に補正
            player.transform.Rotate(0, 0, 180);//プレイヤーを下に回転
            direction = 3;//向きは下   
        }
    }
    //Dキーが押された時
    public void RoteD(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RotaUp();//向きを上に補正
            player.transform.Rotate(0, 0, -90);//プレイヤーを右に回転
            direction = 4;//向きは右      
        }
    }
    //プレイヤーの向きを教える
    public int handover()
    {
        //プレイヤーの向きを返す
        return direction;
    }
}
