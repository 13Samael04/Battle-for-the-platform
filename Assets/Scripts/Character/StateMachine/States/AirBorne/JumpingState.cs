using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class JumpingState : AirBorneState
{
    private readonly JumpingStateConfig _config;
    private readonly Character _character;


    public JumpingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.AirborneStateConfig.JumpingStateConfig;
        _character = character;
    }

    protected Rigidbody2D Rigidbody => _character.Rigidbody;

    public override void Enter()
    {
        base.Enter();

        View.StartJumping();
        //Data.YVelocity = _config.StartYVelocity;
        //Data.YVelocity = _config.MaxForceJump;
        Rigidbody.AddForce(Vector2.up * _config.MaxForceJump, ForceMode2D.Impulse);
    }

    public override void Exit()
    {
        base.Exit();

        View.StopJumping();
    }

    public override void Update()
    {
        base.Update();

        /*if (Data.YVelocity <= 0)
        {
            StateSwitcher.SwitchState<FallingState>();
        }*/
        if (Rigidbody.velocity.y <= 0)
        {
            StateSwitcher.SwitchState<FallingState>();
        }
    }
}
