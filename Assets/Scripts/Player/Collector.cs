using UnityEngine;

public class Collector : MonoBehaviour
{
    private int _coinsInPocket = 0;

    private void ChangeCoinsNumber()
    {
        _coinsInPocket++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            coin.Collect();
            ChangeCoinsNumber();
        }
    }
}
