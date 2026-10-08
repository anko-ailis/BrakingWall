using UnityEngine;

public class DeahtwallMove : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        //当たったオブジェクトがプレイヤーの時
        if (collision.gameObject.CompareTag("player"))
        {
            //ゲームオーバー
            GameOver();
        }
        if (collision.gameObject.CompareTag("bomb"))
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
