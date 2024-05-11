using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderHealthBar : HealthBar
{
    [SerializeField] private Slider _smoothSlider;
    [SerializeField] private float _smoothSliderSpeed = 1.5f;

    private Coroutine currentCoroutine = null;

    private void Awake()
    {
        InitSlider(0, Health.MaxValue, _smoothSlider);
    }

    protected override void DrawHealth(float currentHealth)
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(SmoothFillingOfSlider(currentHealth));
    }

    private IEnumerator SmoothFillingOfSlider(float currentHealth)
    {
        var wait = new WaitForFixedUpdate();

        while (_smoothSlider.value != currentHealth)
        {
            _smoothSlider.value = Mathf.MoveTowards(_smoothSlider.value, currentHealth, _smoothSliderSpeed);
            yield return wait;
        }
    }
}