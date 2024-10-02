using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Movable2 : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2d;
    private Animator _animator;
    private float _rotateAngle = 180;
    private int _runHash = Animator.StringToHash("Run");
    private int _jumpHash = Animator.StringToHash("Jump");
    private int _idleHash = Animator.StringToHash("Idle");
    private float _directionX;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _rigidbody2d.freezeRotation = true;
    }

    private void Update()
    {
        Move(_directionX);
    }

    private void Move(float direction)
    {
        float directionX = Input.GetAxis(Horizontal);
        Vector2 movement = new Vector2(directionX, 0);

        Rotate(directionX);
        _rigidbody2d.velocity = new Vector2(directionX * _speed, _rigidbody2d.velocity.y);

    }

    private void Rotate(float diriction)
    {
        if (diriction < 0)
        {
            transform.eulerAngles = Vector3.up * _rotateAngle;
        }
        else if (diriction > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
}
