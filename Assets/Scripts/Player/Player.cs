using UnityEngine;

[RequireComponent(typeof(Health), typeof(Vampirism))]
public class Player : Humanoid
{
    [SerializeField] private Picker _picker;

    private Vampirism _vampirism;

    private void Awake()
    {
        Health = GetComponent<Health>();
        _vampirism = GetComponent<Vampirism>();
    }

    private void OnEnable()
    {
        _picker.PickedUpFirstAidKit += GetTreatment;
        _vampirism.SucksLife += GetTreatment;
    }

    private void OnDisable()
    {
        _picker.PickedUpFirstAidKit -= GetTreatment;
        _vampirism.SucksLife -= GetTreatment;
    }

    private void GetTreatment(float restoredHealth)
    {
        Health.Value += restoredHealth;
    }
}