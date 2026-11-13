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
    BrakingPlayer BrakPl;
    [SerializeField] Transform pSawn;
    //{
    //    get { return ; }
    //}

    private void Start()
    {
        //    this.transform.SetParent(PlayerPrefab.transform);
        Debug.Log(this.transform.GetChild(0));
        RespawnPoint = SpawnPoiont;
        if (SurvivPlayer == null)
        {
            Debug.Log("Playerいないよ");
            if (this.transform.GetChild(0).gameObject != null)
            {
                Debug.Log("子供がいるよ");
                SurvivPlayer = this.transform.GetChild(0).gameObject;
                Debug.Log(SurvivPlayer);
            }
            else
            {
                Debug.Log("子供いないよ");
                SpawnPlayer();
            }

        }
        else Debug.Log("子供がいるよ");
            //Instantiate(PlayerPrefab, SpawnPoiont, Quaternion.Euler(0f, 0f, 0f));
    }
    private void Update()
    {
        if(SurvivPlayer == null)
        {
            //SpawnPlayer();
        }
        if(Input.GetKey(KeyCode.R))
        {
            //SpawnPlayer();
        }
    }

    //private Transform SPSP(Transform psps)
    //{ 
    //    return BrakPl.PlayerSpawPos;
    //}
    private void SpawnPlayer()
    {
        //Debug.Log(SurvivPlayer);
        if(SurvivPlayer != null) Destroy(SurvivPlayer);
        //pSawn = ChekPoint.TraPoint;
        Debug.Log(BrakPl.PlayerSpawPos);
        pSawn = BrakPl.PlayerSpawPos;
        //Transform pSawn = ChekPoint.TraPoint;
        GameObject NewChild = Instantiate(PlayerPrefab , this.transform , true);
        SurvivPlayer = NewChild;
        NewChild.transform.position = pSawn.position;
    }
}
