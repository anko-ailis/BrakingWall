using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class boomEnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;   //プレイヤー
    [SerializeField] private float moveSpeed;           //移動速度
    [SerializeField] private float destroyCountoTime;   //爆発までの時間
    //[SerializeField] private float fireBomRenge;        //点火までの距離
    [Tooltip("対応したテキストを入れてください")]
    [SerializeField] private float perceptionRange;     //敵がプレイヤーを見つけられる範囲(現在敵のサイズは2)
    [Tooltip("対応したテキストを入れてください")]
    [SerializeField] private TextMeshProUGUI textMesh;  //時間表示のためのテキスト
    [SerializeField] private GameObject explosionDamegEfect;//爆発エフェクト
    [SerializeField] private GameObject explosionNoDamegEfect;//爆発エフェクト
    private bool playerInRange= false;
    private float countTimere = 0;
    private bool Hold = false;                          //つかまれたか
    private bool fireBom = false;                       //カウントダウン開始までの距離
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMesh.text = destroyCountoTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //if(playerObject == null)
        //{
            SearchPalyerObject();
            if (playerObject == null) SelfDestruct();
        Debug.Log(playerInRange+ "[][]" + Hold);
        //}
        if(Hold == false && playerInRange)
        {
            Vector3 direction;
            //Debug.Log("nowMove");
            //プレイヤーとの距離の計算
            //playerDistance = Vector3.Distance(this.transform.position, playerObject.transform.position);
            ////this.transform.LookAt(playerObject.transform);      //プレイヤーの方を向く(3D)
            if (playerObject != null)
            {
                direction = (playerObject.transform.position - this.transform.position);  //向きの計算
            }
            else 
            {
                direction = new Vector3(0, 0, 0);
            }
                this.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);       // ここで向きたい方向に回転させてます
            //Debug.Log(this.gameObject.name + playerDistance + "" + this.transform.rotation);
            this.transform.position = Vector3.MoveTowards(this.transform.position, playerObject.transform.position, moveSpeed / 100);    //プレイヤー方向に直進
        }
        //対象がいれば点火、いなければ自爆
        if (playerObject != null)
        {
            //距離が近くなると爆弾君が点火する
            if (Vector3.Distance(transform.position, playerObject.transform.position) < perceptionRange)
            {
                fireBom = true;
            }
        }
        //動きの一時停止(つかまれたら動かない)
        if (fireBom)
        {
            if(!Hold)
            {
                countTimere += Time.deltaTime;
            }
            //bomCount += (bomCount + Time.time) / 1000;
            //bomCount = Time.time /1000;
            if (countTimere > destroyCountoTime)
            {
                SelfDestruct();
            }
            //Debug.Log(countTimere);
            textMesh.text = (destroyCountoTime - Mathf.Floor(countTimere)).ToString();
             
        }
        //捕まれた状態のテスト用
        if (Input.GetKey(KeyCode.P))
            Hold = true;
        else
            Hold = false;
    }

    /// <summary>
    /// 自爆プログラム
    /// </summary>
    private void SelfDestruct()
    {
        //Debug.Log("自爆するしかねぇ");
        //Debug.Log(Hold);
        //捕まっていないとダメージあり、捕まっていたらダメージなし
        if(!Hold)
        {
            Debug.Log("yesDameg");
            Instantiate(explosionDamegEfect, this.gameObject.transform.position, explosionDamegEfect.transform.rotation);
        }
        else
        {
            Debug.Log("noDameg");
            Instantiate(explosionNoDamegEfect, this.gameObject.transform.position, explosionNoDamegEfect.transform.rotation);
        }
        Destroy(this.gameObject);
    }
    /// <summary>
    /// プレイヤーの探索
    /// </summary>
    private void SearchPalyerObject()
    {
        //Hold = true;
        //playerObject = serchTag(gameObject, "Enemy");

        //テスト
        // "Enemy"タグのオブジェクトを全取得
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player");

        playerObject = null;           // 一番近いオブジェクトを入れる変数
        float minDistance = Mathf.Infinity;  // 最小距離（最初は無限大にしておく）(Mathf.Infinityを書き換えて感知範囲をどうにかする)
        if (perceptionRange < 2 && playerObject == null) 
        {
            minDistance = Mathf.Infinity;  // 感知範囲（最初は無限大にしておく）(Mathf.Infinityを書き換えて感知範囲をどうにかする)

            Debug.Log(minDistance); 
        }
        else 
        {
            minDistance = perceptionRange;  // 感知範囲
            //Debug.Log(minDistance);
        }
        //playerタグ持ちをリストで並べる いなければ自爆
        foreach (GameObject player in enemies)
        {
            // 自分（this）とplayerの距離を計算
            float dist = Vector3.Distance(transform.position, player.transform.position);
            if(dist < Mathf.Infinity)
            {
                playerObject = player;
                Debug.Log("[playerObject]" + playerObject+ "[player]" + player);
            }
            // これまでの最小距離より近ければ更新する
            if (dist < minDistance)
            {
                if (player == null && playerObject == null)
                {
                    SelfDestruct();
                }
                minDistance = dist;
                playerObject = player;
                playerInRange = true;
            }
            else if(gameObject == null) playerInRange = false;

            Debug.Log(this.name +playerInRange);
        }
    }
}
