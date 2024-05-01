using UnityEngine;
using TMPro;

public class UIPainter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private TextMeshProUGUI _enemyHealthText;
    [SerializeField] private TextMeshProUGUI _playerHealthText;

    private void Awake()
    {
        DrawPlayerHealth(_player.Health);
        DrawEnemyHealth(_enemy.Health);
    }

    private void OnEnable()
    {
        _player.HealthHasChanged += DrawPlayerHealth;
        _enemy.HealthHasChanged += DrawEnemyHealth;
    }

    private void OnDisable()
    {
        _player.HealthHasChanged -= DrawPlayerHealth;
        _enemy.HealthHasChanged -= DrawEnemyHealth;
    }

    private void DrawPlayerHealth(float health)
    {
        _playerHealthText.text = health.ToString();
    }

    private void DrawEnemyHealth(float health)
    {
        _enemyHealthText.text = health.ToString();
    }
}
