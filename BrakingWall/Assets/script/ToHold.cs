using UnityEngine;
using UnityEngine.InputSystem;

public class Grab : MonoBehaviour
{

    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;

    private float rayDistance = 0.2f;
    private GameObject grabObj;
    RaycastHit2D hit;

    void Update()
    {
       
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (grabObj == null)
        {
            hit = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);
            if (hit.collider != null && hit.collider.tag == "bomb")
            {
                grabObj = hit.collider.gameObject;
                grabObj.transform.position = grabPoint.position;
                grabObj.transform.SetParent(transform);
            }
        }
        else
        {
            grabObj.transform.SetParent(null);
            grabObj = null;
    }
        
}
}