using UnityEngine;

public class PlayerHealthContainer : MonoBehaviour
{
    private float _baseHealth = 100;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _baseHealth;
    }

    public void IncreasePlayerHealth(float healthRange)
    {
        _currentHealth += healthRange;
        Debug.Log(_currentHealth);
    }

    public void ReducePlayerHealth(float attackRange)
    {
        _currentHealth -= attackRange;
        Debug.Log(_currentHealth);
    }
}
