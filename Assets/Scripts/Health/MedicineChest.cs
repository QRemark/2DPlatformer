using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class MedicineChest : MonoBehaviour
{
    public event Action<MedicineChest> OnCollected;

    public void Collect(out float healthRange)
    {
        OnCollected?.Invoke(this);
        healthRange = 10f;
    }
}
