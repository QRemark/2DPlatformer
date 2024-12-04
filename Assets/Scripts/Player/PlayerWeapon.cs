using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private float _damage = 5f;
    [SerializeField] private float _range = 20f;
    [SerializeField] private Transform _shooterPoint;

    private Transform _playerTransform;

    private void Awake()
    {
        _playerTransform = transform;
    }
 
    public void Shoot()
    {
        //Vector2 shootDirection = _playerTransform.localRotation == Quaternion.Euler(0, 180, 0) ? Vector2.left : Vector2.right;

        Vector2 shootDirection = _playerTransform.right;

        RaycastHit2D hit = Physics2D.Raycast(_shooterPoint.position, shootDirection, _range);

        Debug.DrawRay(_shooterPoint.position, shootDirection * _range, Color.red, 3.5f);

        //CapsuleCollider2D capsuleCollider = hit.collider.GetComponent<CapsuleCollider2D>();

        if (hit.collider != null)
        {
            CapsuleCollider2D capsuleCollider = hit.collider.GetComponent<CapsuleCollider2D>();

            if (capsuleCollider != null)
            {
                EnemyHealthContainer enemyHealth = hit.collider.GetComponentInParent<EnemyHealthContainer>();
                if (enemyHealth != null)
                {
                    enemyHealth.ReduceNumber(_damage);
                    Debug.Log("Рейкаст попал по телу врага и нанес урон");
                }
            }
            else
            {
                Debug.Log("Рейкаст попал, но не в CapsuleCollider2D");
            }
        }
        else
        {
            Debug.Log("Рейкаст никуда не попал");
        }

    }
}
