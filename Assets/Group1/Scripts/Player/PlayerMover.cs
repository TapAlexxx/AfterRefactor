using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerCollisionHandler))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Vector2 _axis;

    private PlayerCollisionHandler _collisionHandler;
    private float _boostTime;
    private float _boostModifier = 1;

    private void Awake()
    {
        _collisionHandler = GetComponent<PlayerCollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.BoosterCollected += OnBoosterCollected;
    }

    private void OnDisable()
    {
        _collisionHandler.BoosterCollected -= OnBoosterCollected;
    }

    private void Update()
    {
        _axis.x = Input.GetAxis("Horizontal");
        _axis.y = Input.GetAxis("Vertical");

        transform.Translate(_axis * _boostModifier * _moveSpeed * Time.deltaTime);
    }

    private void OnBoosterCollected(SpeedBooster booster)
    {
        _boostTime += booster.BoostTime;
        _boostModifier = booster.BoostValue;
        StartCoroutine(BoostMovespeed());
    }

    private IEnumerator BoostMovespeed()
    {
        while (_boostTime > 0)
        {
            yield return new WaitForSeconds(1);
            _boostTime--;
        }
        _boostModifier = 1;
    }
}
