using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue = 100.0f;

    private float _value;

    public event Action<float> HasChanged;

    public float Value
    {
        get => _value;

        set
        {
            _value = Mathf.Clamp(value, 0, MaxValue);
            HasChanged?.Invoke(_value);
        }
    }

    public float MaxValue { get => _maxValue; }

    private void Awake()
    {
        Value = MaxValue;
        HasChanged?.Invoke(Value);
    }
}