using UnityEngine;

public abstract class HumanoidRenderer : MonoBehaviour
{
    protected SpriteRenderer SpriteRenderer;

    public virtual void Flip(float movementDirectionX)
    {
        if (transform.position.x < movementDirectionX)
            SpriteRenderer.flipX = false;
        else if (transform.position.x > movementDirectionX)
            SpriteRenderer.flipX = true;
    }
}