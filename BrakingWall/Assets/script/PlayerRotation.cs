using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerR : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public void RoteA(InputAction.CallbackContext context)
    {
        Debug.Log("‰ñ“]");
        player.transform.Rotate(0, 0, -90);
    }
}
