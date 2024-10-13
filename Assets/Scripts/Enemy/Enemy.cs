using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private CharacterView _view;
    [SerializeField] private CharacterConfig _config;
    [SerializeField] private int _damage;

    private EnemyStateMachine _stateMachine;
    private Rigidbody2D _rigidbody; 

    public Rigidbody2D Rigidbody => _rigidbody;
    public CharacterView View => _view;
    public CharacterConfig Config => _config;

    private void Awake()
    {
        _view.Initialize();
        _rigidbody = GetComponent<Rigidbody2D>();
        _stateMachine = new EnemyStateMachine(this);
        _rigidbody.freezeRotation = true;
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Attack(player);
        }
    }

    private void Attack(Player player)
    {
        player.TakeDamage(_damage);
    }
}
