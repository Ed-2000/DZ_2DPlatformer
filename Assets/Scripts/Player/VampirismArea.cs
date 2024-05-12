using System;
using UnityEngine;

public class VampirismArea : MonoBehaviour
{
    private SpriteRenderer _spriteTriggerZone;

    public event Action<HumanoidAttacker> VictimInAreaOf​Vampirism;
    public event Action<HumanoidAttacker> VictimHasLeftAreaOf​Vampirism;

    private void Awake()
    {
        _spriteTriggerZone = GetComponent<SpriteRenderer>();
        _spriteTriggerZone.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HumanoidAttacker humanoidAttacker))
        {
            VictimInAreaOf​Vampirism?.Invoke(humanoidAttacker);
            _spriteTriggerZone.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HumanoidAttacker humanoidAttacker))
        {
            VictimHasLeftAreaOf​Vampirism?.Invoke(humanoidAttacker);
            _spriteTriggerZone.enabled = false;
        }
    }
}