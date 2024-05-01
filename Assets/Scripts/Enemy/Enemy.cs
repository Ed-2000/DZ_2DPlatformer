using UnityEngine;

public class Enemy : Humanoid
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
            Attack(player);
    }
}
