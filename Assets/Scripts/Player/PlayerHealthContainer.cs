using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthContainer : MonoBehaviour
{
    private float _baseHealth = 100;

    public void IncreaseNumber(float healthRange)
    {
        _baseHealth += healthRange;
        Debug.Log(_baseHealth);
    }

    public void ReduceNumber(float attackRange)
    {
        _baseHealth -= attackRange;
        Debug.Log(_baseHealth);
    }
}
