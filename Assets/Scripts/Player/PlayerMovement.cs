using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerRenderer), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _jumpForce = 3f;
    [SerializeField] private float _distanceToGround = 1.25f;
    [SerializeField] private float _speed = 3f;

    private Rigidbody2D _rigidbody;
    private PlayerRenderer _playerRenderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerRenderer = GetComponent<PlayerRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CheckIsOnGround())
            Jump();

        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis(Horizontal);
        transform.Translate(Vector2.right * horizontalInput * _speed * Time.deltaTime);

        _playerRenderer.SwitchAnimations(horizontalInput);
        _playerRenderer.Flip(horizontalInput);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private bool CheckIsOnGround()
    {
        bool isOnGround = false;
        Debug.DrawRay(transform.position, -Vector2.up * _distanceToGround, Color.yellow);

        if (Physics2D.Raycast(transform.position, -Vector2.up, _distanceToGround, _layerMask))
            isOnGround = true;

        return isOnGround;
    }
}