using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private EnemyMover _enemyMover;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _enemyMover = GetComponent<EnemyMover>(); 
    }

    private void Update()
    {
        if (_enemyMover != null)
        {
            _enemyMover.MoveToNextPoint();
        }
    }

    public void SetPath(EnemyPath path)
    {
        _enemyMover.SetPath(path);
    }

    public void ResetSpeed()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}

