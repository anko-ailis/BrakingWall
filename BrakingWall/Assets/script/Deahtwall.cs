using UnityEngine;

public class DeahtwallMove : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        //当たったオブジェクトがプレイヤーの時
        if (collision.gameObject.CompareTag("Player"))
        {
            //ゲームオーバー
            GameOver();
        }
        if (collision.gameObject.CompareTag("bomb") || collision.gameObject.CompareTag("Color_Blue") || collision.gameObject.CompareTag("Color_Green") || collision.gameObject.CompareTag("Color_Red"))
        {
            Destroy(collision.gameObject);
        }
    }
    private void GameOver()
    {
        // ゲームオーバーの処理をここに記述する
        Debug.Log("死んだ");
    }
}
