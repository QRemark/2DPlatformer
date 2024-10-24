using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CoinPool))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin  _prefab;
    [SerializeField] private List<Transform> _spawnPoints;

    private int _poolCapacity = 5;
    private int _poolMaxSize = 10;

    private CoinPool _coinPool;

    private void Awake()
    {
        _coinPool = gameObject.GetComponent<CoinPool>();
        _coinPool.Initialize(_prefab, _poolCapacity, _poolMaxSize);
    }

    private void Start()
    {
        SpawnCoins();
    }

    public void SpawnCoins()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            Coin coin = _coinPool.GetCoin();

            if (coin != null)
            {
                coin.transform.position = _spawnPoints[i].position;
                coin.Initialize(this);
            }
        }
    }

    public void ReturnCoinInPool(Coin coin)
    {
        _coinPool.ReleaseCoin(coin);
    }
}
