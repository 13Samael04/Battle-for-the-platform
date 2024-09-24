using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class JumpingStateConfig
{
    [SerializeField, Range(0, 10)] private float _maxHeight;
    [SerializeField, Range(0, 10)] public float _timeToReachMaxHeight;

    public float StartYVelocity => _maxHeight / _timeToReachMaxHeight;
    public float MaxHeight => _maxHeight;
    public float TimeToReachMaxHeight => _timeToReachMaxHeight;
}
