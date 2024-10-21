using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] private Transform pointA; 
    [SerializeField] private Transform pointB; 

    public Transform PointA => pointA; 
    public Transform PointB => pointB; 
}