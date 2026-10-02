using UnityEngine;
public class BombThrow : MonoBehaviour
{
    [SerializeField] PlayerRotation playerR;
    private bool moving = false;
    private float speed = 5f; // ˆÚ“®‘¬“x
    private float moveX = 10;
    private float moveY = 0;
    private float direction = 0;
    void Update()
    {
        if (moving == true)
        {
            transform.position += new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
        }
    }
    public void ThrowDirection()
    {
        direction = playerR.handover();
    }
    public void Throw()
    {
        moving = true;
    }
}