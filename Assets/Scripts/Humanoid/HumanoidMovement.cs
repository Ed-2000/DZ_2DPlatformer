using UnityEngine;

public class HumanoidMovement : MonoBehaviour
{
    [SerializeField] protected LayerMask LayerMask;
    [SerializeField] protected float JumpForce = 3f;
    [SerializeField] protected float DistanceToGround = 1.25f;
    [SerializeField] protected float Speed = 3f;

    protected bool IsNeedToJump = false;
    protected Rigidbody2D Rigidbody;

    protected virtual void Jump()
    {
        if (IsOnGround())
            Rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }

    protected bool IsOnGround()
    {
        bool isOnGround = false;
        Debug.DrawRay(transform.position, Vector2.down * DistanceToGround, Color.yellow);

        if (Physics2D.Raycast(transform.position, Vector2.down, DistanceToGround, LayerMask))
            isOnGround = true;

        return isOnGround;
    }
}