using System;
using UnityEngine;

public class Picker : MonoBehaviour
{
    [SerializeField] private int _countOfApple = 0;

    public event Action<float> PickedUpFirstAidKit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Apple apple))
        {
            _countOfApple++;
            Destroy(apple.gameObject);
        }
        else if (collision.transform.TryGetComponent(out FirstAidKit firstAidKit))
        {
            PickedUpFirstAidKit?.Invoke(firstAidKit.RestoredHealth);
            Destroy(firstAidKit.gameObject);
        }
    }
}
