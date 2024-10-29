using System.Collections.Generic;
using UnityEngine;


public class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    //private List<T> _pool;
    private Queue<T> _deactiveObjects;

    private T _prefab;

    public void Initialize(T prefab, int initialSize)
    {
        _prefab = prefab;
        //_pool = new List<T>();
        _deactiveObjects = new Queue<T>();

        for (int i = 0; i < initialSize; i++)
        {
            T obj = Create();
            obj.gameObject.SetActive(false);
            _deactiveObjects.Enqueue(obj);
        }
    }

    public T GetObject()
    {
        T obj;

        if (_deactiveObjects.Count > 0)
            obj = _deactiveObjects.Dequeue();
        else
            obj = Create();

        obj.gameObject.SetActive(true);
        return obj;
    }

    public void ReleaseObject(T obj)
    {
        obj.gameObject.SetActive(false);
        _deactiveObjects.Enqueue(obj);
    }

    private T Create()
    {
        T obj = Instantiate(_prefab);
       // _pool.Add(obj);
        return obj;
    }
}
