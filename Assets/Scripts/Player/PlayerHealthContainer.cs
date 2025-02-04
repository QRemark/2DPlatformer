using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthContainer : MonoBehaviour
{
    private float _baseHealth = 145;
    private float _currentHealth;

    public UnityEvent<float, float> OnHealthChanged = new UnityEvent<float, float>();

    public float MaxHealth => _baseHealth;
    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _baseHealth;
        OnHealthChanged.Invoke(_currentHealth, _baseHealth);
    }

    public void IncreasePlayerHealth(float healthRange)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + healthRange, 0, _baseHealth);
        OnHealthChanged.Invoke(_currentHealth, _baseHealth);
    }

    public void ReducePlayerHealth(float attackRange)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - attackRange, 0, _baseHealth);
        OnHealthChanged.Invoke(_currentHealth, _baseHealth);
    }
}
