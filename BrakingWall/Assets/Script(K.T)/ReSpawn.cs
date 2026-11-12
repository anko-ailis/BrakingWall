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
    [SerializeField] private GameObject Maneger;
    private GameObject SurvivPlayer;
    private Vector3 RespawnPoint ;
    ChekPoint ChekPoint;
    //{
    //    get {return ChekPoint.SpawnPoint; }
    //}

    private void Start()
    {
        //    this.transform.SetParent(PlayerPrefab.transform);
        SurvivPlayer = this.transform.GetChild(0).gameObject;
        RespawnPoint = SpawnPoiont;
        SpawnPlayer();
        //if(SurvivPlayer == null)
        //{
        //    SurvivPlayer = PlayerPrefab;
        //    Instantiate(PlayerPrefab, SpawnPoiont, Quaternion.Euler(0f, 0f, 0f));
        //}
    }
    private void Update()
    {
        if(SurvivPlayer == null)
        {
            SpawnPlayer();
        }
        if(Input.GetKey(KeyCode.R))
        {
            SpawnPlayer();
        }
    }

    private void SpawnPlayer()
    {
        if(SurvivPlayer != null) Destroy(SurvivPlayer);
        //GameObject NewChild = Instantiate(PlayerPrefab, ChekPoint.Point);
        //SurvivPlayer = NewChild;
    }
}
