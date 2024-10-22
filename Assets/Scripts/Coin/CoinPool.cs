using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    private List<Coin> _pool;

    private int _maxSize;

    public void Initialize(Coin prefab, int initialSize, int maxSize)
    {
        _pool = new List<Coin>();
        _maxSize = maxSize;

        for (int i = 0; i < initialSize; i++)
        {
            Coin coin = Instantiate(prefab);
            coin.gameObject.SetActive(false);
            _pool.Add(coin);
        }
    }

    public Coin GetCoin()
    {
        foreach (Coin coin in _pool)
        {
            if (!coin.gameObject.activeInHierarchy)
            {
                coin.gameObject.SetActive(true);
                return coin;
            }
        }

        if (_pool.Count > _maxSize)
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
    }
}
