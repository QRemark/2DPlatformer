using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private List<Enemy> _pool;
    private int _maxSize;

    public void Initialize(Enemy prefab, int initialSize, int maxSize)
    {
        _pool = new List<Enemy>();

        _maxSize = maxSize;

        for (int i = 0; i < initialSize; i++)
        {
            Enemy enemy = Instantiate(prefab);
            enemy.gameObject.SetActive(false);
            _pool.Add(enemy);
        }
    }

    public Enemy GetEnemy()
    {
        foreach (Enemy enemy in _pool)
        {
            if (enemy.gameObject.activeInHierarchy==false)
            {
                enemy.gameObject.SetActive(true);

                return enemy;
            }
        }

        if (_pool.Count < _maxSize)
        {
            Enemy cloneEnemy = Instantiate(_pool[0]);
            cloneEnemy.gameObject.SetActive(true);
            _pool.Add(cloneEnemy);

            return cloneEnemy;
        }

        return null;
    }

    public void ReleaseEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }
}
