using UnityEngine;

public abstract class HumanoidRenderer : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;

    public virtual void Flip(float movementDirectionX)
    {
        if (transform.position.x < movementDirectionX)
            spriteRenderer.flipX = false;
        else if (transform.position.x > movementDirectionX)
            spriteRenderer.flipX = true;
    }
}