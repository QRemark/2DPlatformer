using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private List<Enemy> _pool;
    private Queue<Enemy> _deactiveEnemy;

    private Enemy _prefab;

    private int _maxSize;

    public void Initialize(Enemy prefab, int initialSize, int maxSize)
    {
        _prefab = prefab;
        _pool = new List<Enemy>();
        _deactiveEnemy = new Queue<Enemy>();
        _maxSize = maxSize;

        for (int i = 0; i < initialSize; i++)
        {
            Enemy enemy = Create();
            enemy.gameObject.SetActive(false);
            _deactiveEnemy.Enqueue(enemy);
            //_pool.Add(enemy);
        }
    }

    //public Enemy GetEnemy()
    //{
    //    if (_deactiveEnemy.Count > 0)
    //    {
    //        Enemy enemy = _deactiveEnemy.Dequeue();
    //        enemy.gameObject.SetActive(true);
    //        return enemy;
    //    }

    //    if (_pool.Count < _maxSize)
    //    {
    //        Enemy cloneEnemy = Create();
    //        cloneEnemy.gameObject.SetActive(true);
    //        //_pool.Add(cloneEnemy);

    //        return cloneEnemy;
    //    }

    //    return null;
    //}

    public Enemy GetEnemy()
    {
        Enemy enemy;

        if (_deactiveEnemy.Count > 0)
            enemy = _deactiveEnemy.Dequeue();
            //enemy.gameObject.SetActive(true);
            //return enemy;
        else
            enemy = Create();
            //enemy.gameObject.SetActive(true);
            //return enemy;

        enemy.gameObject.SetActive(true);
        return enemy;
    }

    private Enemy Create()
    {
        Enemy enemy = Instantiate(_prefab);
        _pool.Add(enemy);
        return enemy;
    }
}
