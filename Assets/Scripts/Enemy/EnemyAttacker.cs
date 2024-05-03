using UnityEngine;

[RequireComponent(typeof(Health))]
public class EnemyAttacker : HumanoidAttacker
{
    private void Awake()
    {
        Health = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerAttacker player))
            Attack(player);
    }
}
