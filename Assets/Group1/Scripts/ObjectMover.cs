using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float _movementRadius;
    [SerializeField] private float _moveSpeed;

    private Vector3 _targetPosition;

    private void Start()
    {
        SetNewTargetPosition();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);

        if (transform.position == _targetPosition)
            SetNewTargetPosition();
    }

    public void SetNewTargetPosition()
    {
        _targetPosition = Random.insideUnitCircle * _movementRadius;
    }
}
