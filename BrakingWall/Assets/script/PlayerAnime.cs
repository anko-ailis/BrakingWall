
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private int direction = 0;
    private int beforeDirection = 0;
    private bool change = false;

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
        if (direction != beforeDirection) 
        {
            beforeDirection = direction;
            change = true;
        }

        animator.SetBool("change",change);
        animator.SetInteger("Direction", direction);
        animator.SetBool("IsMoving", isMoving);
        change = false;
    }
}
