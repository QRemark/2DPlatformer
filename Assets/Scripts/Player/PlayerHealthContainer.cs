using UnityEngine;

public class PlayerHealthContainer : HealthContainer
{
    private void Awake()
    {
        _maxHealth = 145; 
    }
}

//public class PlayerHealthContainer : MonoBehaviour, IHealthContainer
//{
//    private float _baseHealth = 145;
//    private float _currentHealth;

//    public event Action<float, float> HealthChanged;

//    public float MaxHealth => _baseHealth;
//    public float CurrentHealth => _currentHealth;

//    private void Start()
//    {
//        _currentHealth = _baseHealth;
//        HealthChanged?.Invoke(_currentHealth, _baseHealth);
//    }

//    public void Increase(float healthRange)
//    {
//        _currentHealth = Mathf.Clamp(_currentHealth + healthRange, 0, _baseHealth);
//        HealthChanged?.Invoke(_currentHealth, _baseHealth);
//    }

//    public void Reduce(float attackRange)
//    {
//        _currentHealth = Mathf.Clamp(_currentHealth - attackRange, 0, _baseHealth);
//        HealthChanged?.Invoke(_currentHealth, _baseHealth);
//    }
//}