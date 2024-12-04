using UnityEngine;

public class EnemyEye : MonoBehaviour
{
    private Collider2D _playerCollider;
    private EnemyMover _enemyMover;
    private EnemyWeapon _enemyWeapon;

    private void Awake()
    {
        _enemyMover = GetComponentInParent<EnemyMover>();
        _enemyWeapon = GetComponentInParent<EnemyWeapon>();
    }

    private void Start()
    {
        _playerCollider = _enemyMover.GetPlayer().GetComponent<Collider2D>();
        //Debug.Log("Коллайдер игрока установлен в EnemyEye");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Что-то вошло в зону видимости");

        //if (collision.TryGetComponent(out Player palyer))
        //    Debug.Log(palyer.name);

        if (collision == _playerCollider)
        {
            Debug.Log("Вижу игрока в OnTriggerEnter2D");
            _enemyMover.WalkPlayerEnterSight();
            _enemyWeapon.StartAttack();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == _playerCollider)
        {
            Debug.Log("игрок ушел");
            _enemyMover.WalkPlayerExitSight();
            _enemyWeapon.StopAttack();
        }
    }
}
