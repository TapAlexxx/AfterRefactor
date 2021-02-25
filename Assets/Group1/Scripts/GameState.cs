using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private EnemyCounter _enemyCounter;
    [SerializeField] private GameObject _endScreen;

    private void OnEnable()
    {
        _enemyCounter.GameEnded += OnGameEnded;
    }

    private void OnDisable()
    {
        _enemyCounter.GameEnded -= OnGameEnded;
    }

    private void OnGameEnded()
    {
        Time.timeScale = 0;
        _endScreen.SetActive(true);
    }
}
