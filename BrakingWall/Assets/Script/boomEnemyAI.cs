using UnityEngine;
using UnityEngine.UIElements;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;   //プレイヤー
    [SerializeField] private float moveSpeed;           //移動速度
    private float playerDistance;                       //プレイヤーとの距離
    private bool Hold = false;                          //つかまれたか
    private bool hiting = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerObject == null)
        {
            Hold = true;
            //playerObject = serchTag(gameObject, "Enemy");

            //テスト
            // "Enemy"タグのオブジェクトを全取得
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player");

            playerObject = null;           // 一番近いオブジェクトを入れる変数
            float minDistance = Mathf.Infinity;  // 最小距離（最初は無限大にしておく）

            foreach (GameObject enemy in enemies)
            {
                // 自分（this）とenemyの距離を計算
                float dist = Vector3.Distance(transform.position, enemy.transform.position);

                // これまでの最小距離より近ければ更新する
                if (dist < minDistance)
                {
                    minDistance = dist;
                    playerObject = enemy;
                }
            }
        }
        if(Hold == false)
        {
            //プレイヤーとの距離の計算
            //playerDistance = Vector3.Distance(this.transform.position, playerObject.transform.position);
            ////this.transform.LookAt(playerObject.transform);      //プレイヤーの方を向く(3D)
            Vector3 direction = (playerObject.transform.position - this.transform.position);  //向きの計算
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);       // ここで向きたい方向に回転させてます
            //Debug.Log(this.gameObject.name + playerDistance + "" + this.transform.rotation);
            this.transform.position = Vector3.MoveTowards(this.transform.position, playerObject.transform.position, moveSpeed / 100);    //プレイヤー方向に直進
        }
        //動きの一時停止(つかまれたら動かない)
        if(Input.GetKey(KeyCode.T)||! hiting)
        {
            Hold = true;
            //this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            Hold = false;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        hiting = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        hiting = true;
    }

}
