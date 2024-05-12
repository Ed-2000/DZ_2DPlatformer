using System;
using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private VampirismArea _area;
    [SerializeField] private float _suctionPower = 1.0f;
    [SerializeField] private float _timeOfAction = 6.0f;

    private HumanoidAttacker _humanoidAttacker;
    private Coroutine _suckLifeCoroutine = null;

    public event Action<float> SucksLife;

    private void OnEnable()
    {
        _area.VictimInAreaOfVampirism += VictimInAreaOfVampirismHandler;
        _area.VictimHasLeftAreaOfVampirism += VictimHasLeftAreaOfVampirismHandler;
    }

    private void OnDisable()
    {
        _area.VictimInAreaOfVampirism -= VictimInAreaOfVampirismHandler;
        _area.VictimHasLeftAreaOfVampirism -= VictimHasLeftAreaOfVampirismHandler;
    }

    private void Update()
    {
        if (_humanoidAttacker != null && _suckLifeCoroutine == null && Input.GetKeyDown(KeyCode.E))
            _suckLifeCoroutine = StartCoroutine(SuckLife(_humanoidAttacker));
    }

    private void VictimInAreaOfVampirismHandler(HumanoidAttacker humanoidAttacker)
    {
        _humanoidAttacker = humanoidAttacker;
    }

    private void VictimHasLeftAreaOfVampirismHandler(HumanoidAttacker humanoidAttacker)
    {
        if (_humanoidAttacker == humanoidAttacker)
        {
            _humanoidAttacker = null;

            if (_suckLifeCoroutine != null)
            {
                StopCoroutine(_suckLifeCoroutine);
                _suckLifeCoroutine = null;
            }
        }
    }

    private IEnumerator SuckLife(HumanoidAttacker humanoidAttacker)
    {
        var wait = new WaitForEndOfFrame();
        float currentTimeOfAction = 0.0f;
        float suctionPower;

        while (currentTimeOfAction <= _timeOfAction)
        {
            currentTimeOfAction += Time.deltaTime;
            suctionPower = _suctionPower * Time.deltaTime;
            SucksLife?.Invoke(suctionPower);
            humanoidAttacker.TakeDamage(suctionPower);

            yield return wait;
        }
    }
}