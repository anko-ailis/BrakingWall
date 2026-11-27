using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] wallMove wallMove; // wallMoveクラスの参照
    [SerializeField] private float movespeed;//移動速度
    [SerializeField] private float walldistance = 10;
    private Rigidbody2D rb;//Rigidbody2Dコンポーネント
    private Vector2 moveInput;//移動入力
    private float wallpositionX; // 壁のX軸 
    private void Start()
    {
        //Rigidbody2Dコンポーネントを取得
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        wallpositionX = wallMove.handover();
        if (wallpositionX + walldistance >= rb.position.x)
        {
            //Debug.Log("asaa");
            //移動入力がある場合、プレイヤーを移動させる
            //Vector2 pos = moveInput.normalized * movespeed * Time.fixedDeltaTime;
            //rb.MovePosition(rb.position + pos);
            rb.MovePosition(rb.position + (moveInput.normalized * movespeed * Time.fixedDeltaTime));
        }

        //Debug.Log($"左：{wallpositionX + walldistance},右：{rb.position.x}");
    }

    //private void Update()
    //{
    //    wallpositionX = wallMove.handover();
    //    if (wallpositionX + walldistance >= rb.position.x)
    //    {
    //        Debug.Log("asaa");
    //        //移動入力がある場合、プレイヤーを移動させる
    //        Vector3 pos = moveInput.normalized * movespeed * Time.fixedDeltaTime;
    //        rb.MovePosition(new Vector2( 100,100));//原因

    //        //this.transform.position += new Vector3(moveInput.x / 5, moveInput.y / 5,0);
    //    }

    //    Debug.Log($"左：{wallpositionX + walldistance},右：{rb.position.x}");
    //}
    //移動入力を受け取るメソッド
    public void OnMove(InputAction.CallbackContext context)
    {
        //移動入力を取得
        moveInput = context.ReadValue<Vector2>();
        //Debug.Log($"hjhj:{moveInput.x},{moveInput.y}");
    }
}                                                                                                                                    