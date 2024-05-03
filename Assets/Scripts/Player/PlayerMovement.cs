using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerRenderer), typeof(Animator))]
public class PlayerMovement : HumanoidMovement
{
    private const string Horizontal = nameof(Horizontal);

    private PlayerRenderer _playerRenderer;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        _playerRenderer = GetComponent<PlayerRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            IsNeedToJump = true;

        Move();
    }

    private void FixedUpdate()
    {
        if (IsNeedToJump == true)
        {
            IsNeedToJump = false;
            Jump();
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis(Horizontal);
        transform.Translate(Vector2.right * horizontalInput * Speed * Time.deltaTime);

        _playerRenderer.SwitchAnimations(horizontalInput);
        _playerRenderer.Flip(horizontalInput);
    }
}