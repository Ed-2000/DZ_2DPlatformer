using UnityEngine;

public class HumanoidMovement : MonoBehaviour
{
    [SerializeField] protected LayerMask _layerMask;
    [SerializeField] protected float _jumpForce = 3f;
    [SerializeField] protected float _distanceToGround = 1.25f;
    [SerializeField] protected float _speed = 3f;

    protected Rigidbody2D _rigidbody;

    protected virtual void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    protected bool CheckIsOnGround()
    {
        bool isOnGround = false;
        Debug.DrawRay(transform.position, -Vector2.up * _distanceToGround, Color.yellow);

        if (Physics2D.Raycast(transform.position, -Vector2.up, _distanceToGround, _layerMask))
            isOnGround = true;

        return isOnGround;
    }
}