using UnityEngine;

[RequireComponent(typeof(Picker))]
public class Player : Humanoid
{
    [SerializeField] private float _amountOfHealthRestoredWhenTreated = 50;
   
    private Picker _picker;

    private void Awake()
    {
        _picker = GetComponent<Picker>();
    }

    private void OnEnable()
    {
        _picker.PickedUpFirstAidKit += GetTreatment;
    }

    private void OnDisable()
    {
        _picker.PickedUpFirstAidKit -= GetTreatment;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Enemy enemy))
            Attack(enemy);
    }

    private void GetTreatment()
    {
        Health += _amountOfHealthRestoredWhenTreated;
    }
}