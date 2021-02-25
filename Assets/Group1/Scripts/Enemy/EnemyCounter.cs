using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;
    [SerializeField] private ObjectSpawner _enemySpawner;

    public event UnityAction GameEnded; 

    private List<Enemy> _enemies = new List<Enemy>();

    private void OnEnable()
    {
        _playerCollisionHandler.EnemyDead += OnEnemyDead;
        _enemySpawner.EnemySpawned += OnEnemySpawned;
    }

    private void OnDisable()
    {
        _playerCollisionHandler.EnemyDead -= OnEnemyDead;
        _enemySpawner.EnemySpawned -= OnEnemySpawned;
    }

    private void OnEnemySpawned(Enemy enemy)
    {
        _enemies.Add(enemy);
    }

    private void OnEnemyDead(Enemy enemy)
    {
        if (_enemies.Contains(enemy))
        {
            _enemies.Remove(enemy);
            Destroy(enemy.gameObject);

            if (_enemies.Count == 0)
            {
                GameEnded?.Invoke();
            }
        }
    }
}
