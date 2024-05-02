using System;
using UnityEngine;

public abstract class Humanoid : MonoBehaviour
{
    [SerializeField] protected float _health = 100;
    [SerializeField] protected float _damage = 10;

    public float Health
    {
        get => _health;

        protected set
        {
            if (value < 0)
                _health = 0;
            else
                _health = value;

            HealthHasChanged?.Invoke(_health);
        }
    }

    public event Action<float> HealthHasChanged;

    public virtual void TakeDamage(float damage)
    {
        Health -= damage;

        if (Health <= 0)
            Destroy(gameObject);
    }

    protected virtual void Attack(Humanoid attacked)
    {
        attacked.TakeDamage(_damage);
    }
}
