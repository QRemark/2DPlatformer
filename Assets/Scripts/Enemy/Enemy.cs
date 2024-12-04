using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D), typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    //private Rigidbody2D _rigidbody;
    private EnemyMover _enemyMover;

    private void Awake()
    {
        //rigidbody = GetComponent<Rigidbody2D>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    //private void Update()
    //{
    //    //_enemyMover.Move();
    //}

    public void SetPath(EnemyPath path)
    {
        _enemyMover.SetPath(path);
    }

    public void SetPlayerTarget(Player player)
    {
        _enemyMover.SetPlayer(player);
    }

    public void ResetSpeed()
    {
        //_rigidbody.velocity = Vector2.zero;
    }
}

