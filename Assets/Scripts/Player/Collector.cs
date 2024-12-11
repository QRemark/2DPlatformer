using UnityEngine;

[RequireComponent(typeof(Wallet), typeof(PlayerHealthContainer))]
public class Collector : MonoBehaviour
{
    private Wallet _wallet;
    private PlayerHealthContainer _healthContainer;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
        _healthContainer = GetComponent<PlayerHealthContainer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MetCoin(collision);
        MetMedicineChest(collision);
    }

    private void MetCoin(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            coin.Collect();
            _wallet.ChangeCoinsNumber();
        }
    }

    private void MetMedicineChest(Collider2D collision)
    {
        if (collision.TryGetComponent(out MedicineChest health))
        {
            health.Collect(out float healtRange);
            _healthContainer.IncreasePlayerHealth(healtRange);
        }
    }
}
