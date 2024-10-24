using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _minDistance = 0.5f;

    private Transform _currentTarget;

    private EnemyPath _currentPath;

    private WaitForSeconds _cooldown;

    private float _waitOnPoint = 5.0f;

    private bool _isWaiting = false;

    private void Awake()
    {
        _cooldown = new WaitForSeconds(_waitOnPoint);
    }

    public void SetPath(EnemyPath enemyPath)
    {
        _currentPath = enemyPath;
    }

    public void MoveToNextPoint()
    {
        if (_isWaiting == false)
        {
            Transform targetPoint;

            float step;

            if (_currentTarget == null || _currentTarget == _currentPath.PointB) 
            {
                targetPoint = _currentPath.PointA;
            }
            else
            {
                targetPoint = _currentPath.PointB;
            }

            step = _speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);

            if (Vector3.Distance(transform.position, targetPoint.position) < _minDistance)
            {
                _currentTarget = targetPoint;
                StartCoroutine(WaitBeforeMove());
            }
        }
    }

    private IEnumerator WaitBeforeMove()
    {
        _isWaiting = true;
        yield return _cooldown;
        _isWaiting = false;
    }
}
