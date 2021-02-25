using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionHandler : MonoBehaviour
{
    public event UnityAction<Enemy> EnemyDead;
    public event UnityAction<SpeedBooster> BoosterCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            EnemyDead?.Invoke(enemy);
        }
        else if (collision.TryGetComponent(out SpeedBooster speedBooster))
        {
            BoosterCollected?.Invoke(speedBooster);
            Destroy(speedBooster.gameObject);
        }
    }
}
