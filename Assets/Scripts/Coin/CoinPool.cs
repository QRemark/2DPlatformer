using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    private List<Coin> _pool;
    private Queue<Coin> _deactiveCoin;

    private Coin _prefab;

    public void Initialize(Coin prefab, int initialSize, int maxSize)
    {
        _prefab = prefab;
        _pool = new List<Coin>();
        _deactiveCoin = new Queue<Coin>();

        for (int i = 0; i < initialSize; i++)
        {
            Coin coin = Create();
            coin.gameObject.SetActive(false);
            _deactiveCoin.Enqueue(coin);
        }
    }

    public Coin GetCoin()
    {
        Coin coin;

        if (_deactiveCoin.Count > 0)
            coin = _deactiveCoin.Dequeue();
        else
            coin = Create();

        coin.gameObject.SetActive(true);
        return coin;
    }

    public void ReleaseCoin(Coin coin)
    {
        coin.gameObject.SetActive(false);
        _deactiveCoin.Enqueue(coin);
    }

    private Coin Create()
    {
        Coin coin = Instantiate(_prefab);
        _pool.Add(coin);
        return coin;
    }
}
