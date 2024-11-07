using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private EnemyMover _enemyMover;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        _enemyMover.Move(_rigidbody);
    }

    public void SetPath(EnemyPath path)
    {
        _enemyMover.SetPath(path);
    }

    public void ResetSpeed()
    {
        _rigidbody.velocity = Vector2.zero;
    }
}

