using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class PlayerRenderer : HumanoidRenderer
{
    private int _isRun = Animator.StringToHash("IsRun");
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SwitchAnimations(float horizontalInput)
    {
        if (horizontalInput == 0)
            _animator.SetBool(_isRun, false);
        else
            _animator.SetBool(_isRun, true);
    }

    public override void Flip(float horizontalInput)
    {
        if (horizontalInput > 0)
            spriteRenderer.flipX = false;
        else if (horizontalInput < 0)
            spriteRenderer.flipX = true;
    }
}
