
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private int direction = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        bool isMoving = x != 0 || y != 0;

        if (isMoving)
        {
            if (y > 0 && Mathf.Abs(y) >= Mathf.Abs(x))
            {
                direction = 1; // è„
            }
            else if (y < 0 && Mathf.Abs(y) >= Mathf.Abs(x))
            {
                direction = 0; // â∫
            }
            else if (x < 0)
            {
                direction = 2; // ç∂
            }
            else if (x > 0)
            {
                direction = 3; // âE
            }
        }

        animator.SetInteger("Direction", direction);
        animator.SetBool("IsMoving", isMoving);

        Debug.Log("X: " + x +
                  " / Y: " + y +
                  " / Direction: " + direction);
    }
}
