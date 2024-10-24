using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    private List<Coin> _pool;
    private Queue<Coin> _deactiveCoin;

    private int _maxSize;

    public void Initialize(Coin prefab, int initialSize, int maxSize)
    {
        _pool = new List<Coin>();
        _deactiveCoin = new Queue<Coin>();
        _maxSize = maxSize;

        for (int i = 0; i < initialSize; i++)
        {
            Coin coin = Instantiate(prefab);
            coin.gameObject.SetActive(false);
            _deactiveCoin.Enqueue(coin); 
            _pool.Add(coin);
        }
    }

    public Coin GetCoin()
    {
        if (_deactiveCoin.Count > 0)
        {
            Coin coin = _deactiveCoin.Dequeue();
            coin.gameObject.SetActive(true);
            return coin ;
        }

        if (_pool.Count < _maxSize)
        {
            Coin newCoin = Instantiate(_pool[0]);
            newCoin.gameObject.SetActive(true);
            _pool.Add(newCoin);
            return newCoin;
        }

        return null;
    }

    public void ReleaseCoin(Coin coin)
    {
        coin.gameObject.SetActive(false);
        _deactiveCoin.Enqueue(coin);
    }
}
