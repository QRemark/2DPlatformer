using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthContainer : MonoBehaviour
{
    private float _baseHealth = 10;

    public void IncreaseNumber(float healthRange)
    {
        _baseHealth += healthRange;
        Debug.Log(_baseHealth);
    }

    public void ReduceNumber(float attackRange)
    {
        _baseHealth -= attackRange;
        Debug.Log("урон по врагу" + _baseHealth);
    }
}