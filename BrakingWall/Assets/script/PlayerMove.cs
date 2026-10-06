using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float movespeed;//移動速度
    private Rigidbody2D rb;//Rigidbody2Dコンポーネント
    private Vector2 moveInput;//移動入力

    private void Start()
    {
        //Rigidbody2Dコンポーネントを取得
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //移動入力がある場合、プレイヤーを移動させる
        Vector2 pos = moveInput.normalized * movespeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + pos);
    }
    //移動入力を受け取るメソッド
    public void OnMove(InputAction.CallbackContext context)
    {
        //移動入力を取得
        moveInput = context.ReadValue<Vector2>();
    }
}                                                                                                                                    