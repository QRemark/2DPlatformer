using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _minDistance = 0.5f;

    private Transform _currentTarget;

    private EnemyPath _currentPath;

    private WaitForSeconds _cooldown;

    private int _currentPointIndex;

    private float _waitOnPoint = 5.0f;

    private bool _isWaiting = false;

    private void Awake()
    {
        _cooldown = new WaitForSeconds(_waitOnPoint);
    }

    public void SetPath(EnemyPath enemyPath)
    {
        _currentPath = enemyPath;
        _currentPointIndex = 0;
        transform.position = _currentPath.Points[_currentPointIndex].position;
    }

    public void MoveToNextPoint()
    {
        if (_isWaiting || _currentPath == null || _currentPath.Points.Count == 0) 
            return;

        Transform targetPoint = _currentPath.Points[_currentPointIndex];

        float step = _speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);

        if (IsTargetReached(targetPoint))
            StartCoroutine(WaitBeforeMove());
    }

    private IEnumerator WaitBeforeMove()
    {
        _isWaiting = true;
        yield return _cooldown;
        _isWaiting = false;

        _currentPointIndex = (++_currentPointIndex) % _currentPath.Points.Count;
    }

    private bool IsTargetReached(Transform targetPoint)
    {
        return transform.position.IsEnoughClose(targetPoint.position, _minDistance);
    }
}
