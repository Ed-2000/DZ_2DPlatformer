using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private float _restoredHealth = 50;

    public float RestoredHealth { get => _restoredHealth; private set => _restoredHealth = value; }
}