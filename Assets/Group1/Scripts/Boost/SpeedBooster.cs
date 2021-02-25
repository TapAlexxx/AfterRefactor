using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField] private float _boostValue;
    [SerializeField] private float _boostTime;

    public float BoostValue => _boostValue;
    public float BoostTime => _boostTime;
}
