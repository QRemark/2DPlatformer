using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
    public event Action<Coin> OnCollected;

    public void Collect()
    {
        OnCollected?.Invoke(this);
    }
}
