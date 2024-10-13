using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterView _view;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private CharacterConfig _config;

    private PlayerInput _input;
    private CharacterStateMachine _stateMachine;
    //private CharacterController _characterController;
    private Rigidbody2D _rigidbody;

    public PlayerInput Input => _input;
    //public CharacterController Controller => _characterController;
    public Rigidbody2D Rigidbody => _rigidbody;
    public CharacterView View => _view;
    public CharacterConfig Config => _config;
    public GroundChecker GroundChecker => _groundChecker;

    private void Awake()
    {
        _view.Initialize();
        //_characterController = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = new PlayerInput();
        _stateMachine = new CharacterStateMachine(this);
        _rigidbody.freezeRotation = true;
    }

    private void Update()
    {
        _stateMachine.HandleInput();

        _stateMachine.Update();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}
