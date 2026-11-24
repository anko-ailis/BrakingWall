using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    [Tooltip("スポーンさせるプレイヤーとなるPrefab")]
    [SerializeField] private GameObject PlayerPrefab;
    [Tooltip("初期スポーン")]
    [SerializeField] private Vector3 SpawnPoiont;
    [SerializeField] private GameObject SurvivPlayer;
    BrakingPlayer BrakPl;
    [Tooltip("以下確認用")]
    [SerializeField] Vector3 pSawn;         //以下確認用
    [SerializeField] GameObject NewChild;
    //{
    //    get { return ; }
    //}

    private void Start()
    {
        BrakPl = this.transform.GetChild(0).gameObject.GetComponent<BrakingPlayer>();
        SpawnChek();
        //    this.transform.SetParent(PlayerPrefab.transform);
        Debug.Log(this.transform.GetChild(0));
        SurvivPlayer = this.transform.GetChild(0).gameObject;
        NewChild = this.transform.GetChild(0).gameObject;
        if (SurvivPlayer == null)
        {
            Debug.Log("Playerいないよ");
            if (this.transform.GetChild(0).gameObject != null)
            {
                Debug.Log("子供ができたよ");
                SurvivPlayer = this.transform.GetChild(0).gameObject;
                Debug.Log(SurvivPlayer);
            }
            else
            {
                Debug.Log("子供うんでないお");
                SpawnPlayer();
            }

        }
        else Debug.Log("子供がいるよ");
            //Instantiate(PlayerPrefab, SpawnPoiont, Quaternion.Euler(0f, 0f, 0f));
    }
    private void Update()
    {
        if (SurvivPlayer == null)
        {
            SurvivPlayer = Instantiate(PlayerPrefab, this.transform, true);
            SpawnPlayer();
            BrakPl = this.transform.GetChild(0).gameObject.GetComponent<BrakingPlayer>();
            //SpawnChek();
            //Debug.Log(";;;;");

        }
        if (Input.GetKeyDown(KeyCode.R))//&& ChekTime + 1 < Time.deltaTime
        {
            
            //SpawnChek();
            SpawnPlayer();
        }
    }

    public void Spawn()
    {
        SpawnPlayer();
    }
    //private Transform SPSP(Transform psps)
    //{ 
    //    return BrakPl.PlayerSpawPos;
    //}
    private void SpawnPlayer()
    {
        //float SposX, SposY, SposZ;
        //Debug.Log(SurvivPlayer);
        //pSawn = ChekPoint.TraPoint;
        if (SurvivPlayer != null)
        {
            BrakPl = this.transform.GetChild(0).gameObject.GetComponent<BrakingPlayer>();
            //SposX = BrakPl.PlayerSpawPos.transform.position.x;      //座標取得
            //SposY = BrakPl.PlayerSpawPos.transform.position.y;
            //SposZ = BrakPl.PlayerSpawPos.transform.position.z;
            //pSawn = new Vector3(SposX, SposY, SposZ);
        }
        Debug.Log(BrakPl.PlayerSpawPos);
        //Transform pSawn = ChekPoint.TraPoint;
        NewChild = Instantiate(PlayerPrefab , this.transform , true);   //子供としてプレイヤーを生む
        if (SurvivPlayer != null) Destroy(SurvivPlayer);            //プレイヤーがいるなら古いほうを消す
        SurvivPlayer = NewChild;
        Debug.Log(BrakPl.PlayerSpawPos.transform.position);
        NewChild.transform.position = BrakPl.PlayerSpawPos.transform.position; //リスポーン地点に移動
        BrakPl = this.transform.GetChild(0).gameObject.GetComponent<BrakingPlayer>();//参照元を更新
        //NewChild.transform.position = pSawn.position;
    }
    //初期スポーン地点をプレイヤーの初期位置にする
    private void SpawnChek() 
    {
        SpawnPoiont = new Vector3(this.transform.GetChild(0).position.x,
    this.transform.GetChild(0).position.y,
    this.transform.GetChild(0).position.z);
    }
}
