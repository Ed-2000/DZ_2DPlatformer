using UnityEngine;

public abstract class HumanoidAttacker : MonoBehaviour
{
    [SerializeField] protected float Damage = 10;

    protected Health Health;

    public virtual void TakeDamage(float damage)
    {
        Health.Value -= damage;

        if (Health.Value <= 0)
            Destroy(gameObject);
    }

    protected virtual void Attack(HumanoidAttacker attacked)
    {
        attacked.TakeDamage(Damage);
    }
}
