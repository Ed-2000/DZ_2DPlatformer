using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerAttacker : HumanoidAttacker
{
    private void Awake()
    {
        Health = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out EnemyAttacker enemy))
            Attack(enemy);
    }
}
