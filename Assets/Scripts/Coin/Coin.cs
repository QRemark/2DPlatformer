using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
    public event Action<Coin> OnCollected;

    //private CoinSpawner _coinSpawner;

    //public void Initialize(CoinSpawner spawner)
    //{
    //    _coinSpawner = spawner;
    //}

    public void Collect()
    {
        OnCollected?.Invoke(this);
    }
}
