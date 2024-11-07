using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthContainer : MonoBehaviour
{
    private int _health = 100;

    public void IncreaseNumber()
    {
        _health += 10;
        Debug.Log(_health);
    }

    public void ReduceNumber()
    {
        _health -= 10;
        Debug.Log(_health);
    }
}
