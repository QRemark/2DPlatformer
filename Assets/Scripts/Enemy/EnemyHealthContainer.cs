using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthContainer : MonoBehaviour
{
    private float _baseHealth = 10;

    public void ReduceHealthEnemy(float attackRange)
    {
        _baseHealth -= attackRange;
    }
}