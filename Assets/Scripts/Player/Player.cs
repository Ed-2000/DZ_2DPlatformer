using UnityEngine;

[RequireComponent(typeof(Picker), typeof(Health))]
public class Player : Humanoid
{
    private Picker _picker;

    private void Awake()
    {
        _picker = GetComponent<Picker>();
        Health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _picker.PickedUpFirstAidKit += GetTreatment;
    }

    private void OnDisable()
    {
        _picker.PickedUpFirstAidKit -= GetTreatment;
    }

    private void GetTreatment(float restoredHealth)
    {
        Health.Count += restoredHealth;
    }
}