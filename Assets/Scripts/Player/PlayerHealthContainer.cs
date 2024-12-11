using UnityEngine;

public class PlayerHealthContainer : MonoBehaviour
{
    private float _baseHealth = 100;

    public void IncreasePlayerHealth(float healthRange)
    {
        _baseHealth += healthRange;
    }

    public void ReducePlayerHealth(float attackRange)
    {
        _baseHealth -= attackRange;
    }
}
