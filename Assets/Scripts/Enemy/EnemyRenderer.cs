using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyRenderer : HumanoidRenderer
{
    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
}
