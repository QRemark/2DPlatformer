using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _minDistancePoint = 0.5f;
    [SerializeField] private float _minDistancePlayer = 1.0f;
    [SerializeField] private Rigidbody2D _target;
    //[SerializeField] private Player _target;

    //private Transform _currentTarget;

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

    public void Move(Rigidbody2D rigidbody)
    {
        //Transform playerPoint = _target.transform;

        if (IsTargetReached(_target.transform, _minDistancePlayer))
        {
            Vector2 direction = (_target.position - (Vector2)transform.position).normalized;
            rigidbody.velocity = direction * _speed * 1.5f;
        }
        else
        {
            MoveToNextPoint();
        }
    }

    private void MoveToNextPoint()
    {
        if (_isWaiting || _currentPath == null || _currentPath.Points.Count == 0) 
            return;

        Transform targetPoint = _currentPath.Points[_currentPointIndex];

        float step = _speed * Time.deltaTime;

        //transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, step);

        if (IsTargetReached(targetPoint, _minDistancePoint))
            StartCoroutine(WaitBeforeMove());
    }

    private IEnumerator WaitBeforeMove()
    {
        _isWaiting = true;
        yield return _cooldown;
        _isWaiting = false;

        _currentPointIndex = (++_currentPointIndex) % _currentPath.Points.Count;
    }

    private bool IsTargetReached(Transform targetPoint, float minDistance)
    {
        return transform.position.IsEnoughClose(targetPoint.position, minDistance);
    }
}
