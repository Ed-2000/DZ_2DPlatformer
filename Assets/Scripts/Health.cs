using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float _healthCount = 100;
    
    public event Action<float> HealthHasChanged;

    public float Count
    {
        get => _healthCount;

        set
        {
            if (value < 0)
                _healthCount = 0;
            else
                _healthCount = value;

            HealthHasChanged?.Invoke(_healthCount);
        }
    }
}
