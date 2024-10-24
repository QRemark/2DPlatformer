using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
    private CoinSpawner _coinSpawner;

    public void Initialize(CoinSpawner spawner)
    {
        _coinSpawner = spawner;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            _coinSpawner.ReturnCoinInPool(this);
            player.CollectCoin();
        }
    }
}
