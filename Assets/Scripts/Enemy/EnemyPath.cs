using UnityEngine;
using System.Collections.Generic;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] private List<Transform> _points; 

    public List<Transform> Points => _points; 
}