using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _minDistancePoint = 1.5f;
    //[SerializeField] private float _minDistancePlayer = 1.0f;

    private Player _player;
    private Rigidbody2D _enemyBody;

    private EnemyPath _currentPath;

    private WaitForSeconds _cooldown;

    private int _currentPointIndex;

    private float _waitOnPoint = 5.0f;
    private float _enemyRun = 1.5f;

    private bool _isWaiting = false;
    private bool _isPlayerInSight = false;

    private void Awake()
    {
        _cooldown = new WaitForSeconds(_waitOnPoint);
        _enemyBody = GetComponent<Rigidbody2D>();
    }

    public void SetPath(EnemyPath enemyPath)
    {
        _currentPath = enemyPath;
        _currentPointIndex = 0;
        transform.position = _currentPath.Points[_currentPointIndex].position;
    }

    public Player GetPlayer() => _player;

    public void SetPlayer(Player target) => _player = target;

    //public void Move()
    private void Update()
    {
        if (_isPlayerInSight && _player != null)
        {
            MoveToPlayer();
            Debug.Log("��� �� �������");
        }
        else
        {
            MoveToNextPoint();
        }
    }

    public void WalkPlayerEnterSight()
    {
        Debug.Log("���� ������");
        _isPlayerInSight = true;
    }

    public void WalkPlayerExitSight()
    {
        Debug.Log("� �� ���� ������");
        _isPlayerInSight = false;
        //_player = null;
        _enemyBody.velocity = Vector2.zero;
        _currentPointIndex = FindNearestPointIndex();
    }

    private int FindNearestPointIndex()
    {
        if (_currentPath == null || _currentPath.Points.Count == 0)
            return 0;

        float minDistance = float.MaxValue;
        int nearestIndex = 0;

        for (int i = 0; i < _currentPath.Points.Count; i++)
        {
            float distance = Vector2.Distance(transform.position, _currentPath.Points[i].position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestIndex = i;
            }
        }

        return nearestIndex;
    }


    private void MoveToPlayer()
    {
        Vector2 direction = ((Vector2)_player.transform.position - (Vector2)transform.position).normalized;
        _enemyBody.velocity = direction * _speed * _enemyRun;
    }

    private void MoveToNextPoint()
    {
        if (_isWaiting || _currentPath == null || _currentPath.Points.Count == 0)
            return;

        Transform targetPoint = _currentPath.Points[_currentPointIndex];

        float step = _speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, step);

        if (IsTargetReached(targetPoint, _minDistancePoint))
            StartCoroutine(WaitBeforeMove());
    }

    private IEnumerator WaitBeforeMove()
    {
        //if (_isWaiting) yield break;///

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
