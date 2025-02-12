using UnityEngine;

public class EnemyHealthContainer : HealthContainer
{
    private void Awake()
    {
        _maxHealth = 60; 
    }
}

//public class EnemyHealthContainer : MonoBehaviour, IHealthContainer
//{
//    private float _baseHealth = 30;
//    private float _currentHealth;

//    public event Action<float, float> HealthChanged;

//    public float MaxHealth => _baseHealth;
//    public float CurrentHealth => _currentHealth;

//    private void Start()
//    {
//        _currentHealth = _baseHealth;
//        HealthChanged?.Invoke(_currentHealth, _baseHealth);
//    }

//    public void Increase(float volume)
//    {
//        _currentHealth = Mathf.Clamp(_currentHealth + volume, 0, _baseHealth);
//        HealthChanged?.Invoke(_currentHealth, _baseHealth);
//    }

//    public void Reduce(float volume)
//    {
//        _currentHealth = Mathf.Clamp(_currentHealth - volume, 0, _baseHealth);
//        HealthChanged?.Invoke(_currentHealth, _baseHealth);
//    }
//}