using UnityEngine;
using UnityEngine.UIElements;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject playerObject;   //プレイヤー
    [SerializeField] float moveSpeed;           //移動速度
    float playerDistance;                       //プレイヤーとの距離
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーとの距離の計算
        //playerDistance = Vector3.Distance(this.transform.position, playerObject.transform.position);
        ////this.transform.LookAt(playerObject.transform);      //プレイヤーの方を向く(3D)
        Vector3 dir = (playerObject.transform.position - this.transform.position);  //向きの計算
        this.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);       // ここで向きたい方向に回転させてます
        Debug.Log(this.gameObject.name + playerDistance +"" + this.transform.rotation);
        this.transform.position = Vector3.MoveTowards(this.transform.position, playerObject.transform.position, moveSpeed /100);    //プレイヤー方向に直進
    }
}
