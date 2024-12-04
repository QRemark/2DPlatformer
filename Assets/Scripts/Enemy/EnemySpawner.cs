using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(EnemyPool))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private List<EnemyPath> _enemyPaths;
    [SerializeField] private Player _palyerTarget;

    private int _poolCapacity = 3;

    //private EnemyMover _enemyMover;

    private EnemyPool _enemyPool;

    private void Awake()
    {
        _enemyPool = gameObject.GetComponent<EnemyPool>();
        _enemyPool.Initialize(_prefab, _poolCapacity);
    }

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        for (int i = 0; i < _enemyPaths.Count; i++)
        {
            Enemy enemy = _enemyPool.GetObject();
            
            if (enemy != null)
            {
                enemy.SetPath(_enemyPaths[i]);
                enemy.transform.position = _enemyPaths[i].Points[0].position;
                enemy.ResetSpeed();

                //_enemyMover = enemy.GetComponent<EnemyMover>();
                //if (_enemyMover != null)
                //{
                    Debug.Log("÷ель у врага задана");
                    enemy.SetPlayerTarget(_palyerTarget);

                //}
            }
        }
    }
}