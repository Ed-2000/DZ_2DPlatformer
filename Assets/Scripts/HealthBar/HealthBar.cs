using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health Health;

    protected void InitSlider(float minValue, float maxValue, Slider slider)
    {
        slider.minValue = minValue;
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }

    private void OnEnable()
    {
        Health.HasChanged += DrawHealth;
    }

    private void OnDisable()
    {
        Health.HasChanged -= DrawHealth;
    }

    protected abstract void DrawHealth(float currentHealth);
}