using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;   //プレイヤー
    [SerializeField] private float moveSpeed;           //移動速度
    [SerializeField] private float destroyCountoTime;   //プレイヤーとの距離
    [SerializeField] private float fireBomRenge;        //点火までの距離
    [SerializeField] private TextMeshProUGUI textMesh;  //時間表示のための
    [SerializeField] private GameObject explosionDamegEfect;//爆発エフェクト
    [SerializeField] private GameObject explosionNoDamegEfect;//爆発エフェクト
    private float countTimere = 0;
    private bool Hold = false;                          //つかまれたか
    private bool hiting = true;                         //当たっているか
    private bool fireBom = false;                       //カウントダウン開始までの距離
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMesh.text = destroyCountoTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerObject == null)
        {
            SearchPalyerObject();
            if (playerObject == null) SelfDestruct();
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
        //if(Input.GetKey(KeyCode.T)||! hiting)
        //{
        //    Hold = true;
        //    //this.transform.eulerAngles = new Vector3(0, 0, 0);
        //}
        //else
        //{
        //    Hold = false;
        //}
        //対象がいれば点火、いなければ自爆
        if (playerObject != null)
        {
            //距離が近くなると爆弾君が点火する
            if (Vector3.Distance(transform.position, playerObject.transform.position) < fireBomRenge)
            {
                fireBom = true;
            }
        }
        if (fireBom)
        {
            countTimere += Time.deltaTime;
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        hiting = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        hiting = true;
    }
    /// <summary>
    /// 自爆プログラム
    /// </summary>
    private void SelfDestruct()
    {
        Debug.Log("自爆するしかねぇ");
        Debug.Log(Hold);
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
                if (enemy == null)
                {
                    SelfDestruct();
                }
                minDistance = dist;
                playerObject = enemy;
            }
        }
    }
}
