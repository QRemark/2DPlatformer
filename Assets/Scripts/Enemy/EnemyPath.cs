using UnityEngine;
using System.Collections.Generic;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] private List<Transform> _points; 
    //[SerializeField] private Transform _pointB; 

    public List<Transform> Points => _points; 
    //public Transform PointB => _pointB; 
}