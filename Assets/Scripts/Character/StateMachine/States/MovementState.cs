using UnityEngine;

public class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;

    private readonly Character _character;

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _character = character;
    }

    protected PlayerInput Input => _character.Input;
    //protected CharacterController CharacterController => _character.Controller;
    protected Rigidbody2D Rigidbody => _character.Rigidbody;
    protected CharacterView View => _character.View;

    private Quaternion TurnRight => new Quaternion(0, 0, 0, 0);
    private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

    public virtual void Enter()
    {
        //Debug.Log(GetType());

        View.StartMovement();
        AddInputActionsCallbacks();
    }

    public virtual void Exit() 
    {
        View.StopMovement();
        RemoveInputActionsCallback();
    }


    public virtual void HandleInput()
    {
        Data.XInput = ReadHorizontalInput();
        Data.XVelocity = Data.XInput * Data.Speed;
    }

    public virtual void Update()
    {
        Vector3 velocity = GetConvertedVelocity();

        //CharacterController.Move(velocity * Time.deltaTime);
        Rigidbody.velocity = velocity;

        _character.transform.rotation = GetRotationFrom(velocity);
    }

    protected virtual void AddInputActionsCallbacks() { }

    protected virtual void RemoveInputActionsCallback() { }

    protected bool IsHorizontalInputZero() => Data.XInput == 0;

    private Quaternion GetRotationFrom(Vector3 velocity)
    {
        if(velocity.x > 0)
        {
            return TurnRight;
        }
        if(velocity.x < 0)
        {
            return TurnLeft;
        }

        return _character.transform.rotation;
    }

    private Vector3 GetConvertedVelocity() => new Vector3(Data.XVelocity, Rigidbody.velocity.y, 0);

    private float ReadHorizontalInput() => Input.Movement.Move.ReadValue<float>();
}
