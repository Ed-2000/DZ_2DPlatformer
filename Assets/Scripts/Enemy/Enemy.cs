using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : Humanoid
{
    private void Awake()
    {
        Health = GetComponent<Health>();
    }
}
