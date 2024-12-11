using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyMover _enemyMover;
    private EnemyWeapon _enemyWeapon;
    private Player _player;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _enemyWeapon = GetComponent<EnemyWeapon>();
        EnemyEye eye = GetComponentInChildren<EnemyEye>();
        eye.OnEnterSight += HandleEnterSight;
        eye.OnExitSight += HandleExitSight;
    }

    public void SetPlayerTarget(Player player)
    {
        _player = player;
        _enemyMover.SetPlayer(player);
    }

    public void SetPath(EnemyPath path)
    {
        _enemyMover.SetPath(path);
    }

    private void HandleEnterSight(Collider2D collider)
    {
        if (collider.gameObject == _player.gameObject)
        {
            _enemyMover.WalkPlayerEnterSight();
            _enemyWeapon.StartAttack();
        }
    }

    private void HandleExitSight(Collider2D collider)
    {
        if (collider.gameObject == _player.gameObject)
        {
            _enemyMover.WalkPlayerExitSight();
            _enemyWeapon.StopAttack();
        }
    }
}

