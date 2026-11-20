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
            BrakPl = this.transform.GetChild(0).gameObject.GetComponent<BrakingPlayer>();
            //SpawnChek();
            Debug.Log(";;;;");
            SpawnPlayer();
        }
        if (Input.GetKeyDown(KeyCode.R))//&& ChekTime + 1 < Time.deltaTime
        {
            
            //SpawnChek();
            SpawnPlayer();
        }
    }

    //private Transform SPSP(Transform psps)
    //{ 
    //    return BrakPl.PlayerSpawPos;
    //}
    private void SpawnPlayer()
    {
        float SposX, SposY, SposZ;
        //Debug.Log(SurvivPlayer);
        //pSawn = ChekPoint.TraPoint;
        BrakPl = this.transform.GetChild(0).gameObject.GetComponent<BrakingPlayer>();
        Debug.Log(BrakPl.PlayerSpawPos);
        SposX = BrakPl.PlayerSpawPos.transform.position.x;
        SposY = BrakPl.PlayerSpawPos.transform.position.y;
        SposZ = BrakPl.PlayerSpawPos.transform.position.z;
        pSawn = new Vector3(SposX, SposY, SposZ);
        //Transform pSawn = ChekPoint.TraPoint;
        NewChild = Instantiate(PlayerPrefab , this.transform , true);
        if (SurvivPlayer != null) Destroy(SurvivPlayer);
        SurvivPlayer = NewChild;
        Debug.Log(BrakPl.PlayerSpawPos.transform.position);
        NewChild.transform.position = BrakPl.PlayerSpawPos.transform.position; 
        BrakPl = this.transform.GetChild(0).gameObject.GetComponent<BrakingPlayer>();
        //NewChild.transform.position = pSawn.position;
    }
    private void SpawnChek() 
    {
        SpawnPoiont = new Vector3(this.transform.GetChild(0).position.x,
    this.transform.GetChild(0).position.y,
    this.transform.GetChild(0).position.z);
    }
}
