using System.Collections.Generic;
using UnityEngine;

//public class EnemyPool : MonoBehaviour
public class EnemyPool : Pool<Enemy>
{
    //private List<Enemy> _pool;
    //private Queue<Enemy> _deactiveEnemy;

    //private Enemy _prefab;

    //public void Initialize(Enemy prefab, int initialSize)
    //{
    //    _prefab = prefab;
    //    _pool = new List<Enemy>();
    //    _deactiveEnemy = new Queue<Enemy>();

    //    for (int i = 0; i < initialSize; i++)
    //    {
    //        Enemy enemy = Create();
    //        enemy.gameObject.SetActive(false);
    //        _deactiveEnemy.Enqueue(enemy);
    //    }
    //}

    //public Enemy GetEnemy()
    //{
    //    Enemy enemy;

    //    if (_deactiveEnemy.Count > 0)
    //        enemy = _deactiveEnemy.Dequeue();
    //    else
    //        enemy = Create();

    //    enemy.gameObject.SetActive(true);
    //    return enemy;
    //}

    //private Enemy Create()
    //{
    //    Enemy enemy = Instantiate(_prefab);
    //    _pool.Add(enemy);
    //    return enemy;
    //}
}
