using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyRenderer : HumanoidRenderer
{
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
