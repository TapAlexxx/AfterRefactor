using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private int _count;
    [SerializeField] private float _radius;

    public event UnityAction<Enemy> EnemySpawned;

    private void Start()
    {
        for (int i = 0; i < _count; i++)
        {
            GameObject gameObject = Instantiate(_template, Random.insideUnitCircle * _radius, Quaternion.identity);
            if (gameObject.TryGetComponent(out Enemy enemy))
            {
                EnemySpawned?.Invoke(enemy);
            }
        }
    }
}
