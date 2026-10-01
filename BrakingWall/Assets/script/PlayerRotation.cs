using UnityEngine;
using UnityEngine.InputSystem;

public enum Direction
{
    Up = 1,
    Left = 2,
    Down = 3,
    Right = 4
}
public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private int direction = 1;
    private void Rota()
    {
        if (direction == (int)Direction.Up)
        {
            player.transform.Rotate(0, 0, 0);
        }
        else if (direction == (int)Direction.Left)
        {
            player.transform.Rotate(0, 0, -90);
        }
        else if (direction == (int)Direction.Down)
        {
            player.transform.Rotate(0, 0, 180);
        }
        else if (direction == (int)Direction.Right)
        {
            player.transform.Rotate(0, 0, 90);
        }
    }
    public void RoteW(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            Rota();
            direction = 1;
        }
    }
    public void RoteA(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Rota();
            player.transform.Rotate(0, 0, 90);
            direction = 2;
        }
        
    }
    public void RoteS(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Rota();
            player.transform.Rotate(0, 0, 180);
            direction = 3;
        }
        
    }
    public void RoteD(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Rota();
            player.transform.Rotate(0, 0, -90);
            direction = 4;
        }
       
    }
    public int handover()
    {
        return direction;
    }
}
