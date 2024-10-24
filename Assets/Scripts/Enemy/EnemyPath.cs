using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] private Transform _pointA; 
    [SerializeField] private Transform _pointB; 

    public Transform PointA => _pointA; 
    public Transform PointB => _pointB; 
}