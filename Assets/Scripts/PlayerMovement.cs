using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpForce = 3f;
    [SerializeField] private float _distanceToGround = 1.25f;

    private Animator _animator;
    private int _isRun = Animator.StringToHash("IsRun");
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
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
        Flip(horizontalInput);

        if (horizontalInput == 0)
            _animator.SetBool(_isRun, false);
        else
            _animator.SetBool(_isRun, true);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);
    }

    private bool CheckIsOnGround()
    {
        bool isOnGround = false;
        Debug.DrawRay(transform.position, -Vector2.up * _distanceToGround, Color.yellow);

        if (Physics2D.Raycast(transform.position, -Vector2.up, _distanceToGround, _layerMask))
            isOnGround = true;

        return isOnGround;
    }

    void Flip(float horizontalInput)
    {
        if (horizontalInput > 0)
            _spriteRenderer.flipX = false;
        else if (horizontalInput < 0)
            _spriteRenderer.flipX = true;
    }
}