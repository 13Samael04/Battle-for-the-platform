using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _radius;
    [SerializeField, Range(0.01f, 1f)] private float _distanceToCheck;

    public bool IsTouch {  get; private set; }

    private void Update() => IsTouch = Physics2D.CircleCast(transform.position, _radius, Vector2.down, _distanceToCheck, _ground);
    
}
