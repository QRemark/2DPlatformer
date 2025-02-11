using UnityEngine;
using UnityEngine.UI;

public class PercentHealthbar : MonoBehaviour
{
    [SerializeField] private PlayerHealthContainer _playerHealth;
    [SerializeField] private Slider _percentHealthbar;

    private void Start()
    {
        _playerHealth.HealthChanged += UpdatePercentHealthbar;
        UpdatePercentHealthbar(_playerHealth.CurrentHealth, _playerHealth.MaxHealth);
    }

    private void UpdatePercentHealthbar(float currentHealth, float maxHealth)
    {
        _percentHealthbar.value = currentHealth / maxHealth;
    }

    private void OnDestroy()
    {
        _playerHealth.HealthChanged -= UpdatePercentHealthbar;
    }
}
