using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grab : MonoBehaviour
{

    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;

    private float rayDistance = 0.2f;
    private Vector2 bombmove = new Vector2 (0,10);
    private bool hold = false;
    private GameObject bomb;
    RaycastHit2D hit;

    void Update()
    {
        if (hold == true)
        {
            Hold();
        }
       
    }
    public void Ray(InputAction.CallbackContext context)
    {
        
        hit = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);
        if (hit.collider != null && hit.collider.tag == "bomb")
        {
            bomb = hit.collider.gameObject;
            if (hold == false)
            {
                hold = true;
            }
            else
            {
                Throw();
                hold = false;
            }
        }
    }
    void Hold()
    {
        bomb.transform.position = grabPoint.position;
    }
    
}