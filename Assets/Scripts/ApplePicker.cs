using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    [SerializeField] private int _countOfApple = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Apple apple))
        {
            _countOfApple++;
            Destroy(apple.gameObject);
        }
    }
}
