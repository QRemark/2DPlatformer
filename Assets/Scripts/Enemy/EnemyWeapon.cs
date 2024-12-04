using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private PlayerHealthContainer _playerHealth;
    
    private float _attackRadius = 2f;
    private float _attackColldown = 2f;

    private bool _isAttack = false;
    private float _nextAttackTime = 0f;
    private float _attckRange = 5f;

    private void Start()
    {
        Player player = GetComponentInParent<EnemyMover>().GetPlayer();
        _playerHealth = player.GetComponent<PlayerHealthContainer>();
    }

    private void Update()
    {
        if (_isAttack == false || Time.time < _nextAttackTime)
            return;

        AttackPlayer();
    }

    public void StartAttack() => _isAttack = true;

    public void StopAttack() => _isAttack = false;

    private void AttackPlayer()
    {
        float distance = Vector2.Distance(transform.position, _playerHealth.transform.position);

        if (distance <= _attackRadius)
        {
            Debug.Log("Враг наносит урон игроку");
            _playerHealth.ReduceNumber(_attckRange);
            _nextAttackTime = Time.time + _attackColldown;
        }
    }
}
