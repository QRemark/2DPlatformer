using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(EnemyPool))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private List<EnemyPath> _enemyPaths;

    private int _poolCapacity = 3;
    private int _poolMaxSize = 5;

    private EnemyPool _enemyPool;

    private void Awake()
    {
        _enemyPool = gameObject.GetComponent<EnemyPool>();
        _enemyPool.Initialize(_prefab, _poolCapacity, _poolMaxSize);
    }

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        for (int i = 0; i < _enemyPaths.Count; i++)
        {
            Enemy enemy = _enemyPool.GetEnemy();
            
            if (enemy != null)
            {
                enemy.SetPath(_enemyPaths[i]);
                enemy.transform.position = _enemyPaths[i].Points[0].position;
                enemy.ResetSpeed();
            }
        }
    }
}