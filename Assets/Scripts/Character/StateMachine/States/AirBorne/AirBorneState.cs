using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBorneState : MovementState
{
    private readonly AirborneStateConfig _config;

    public AirBorneState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.AirborneStateConfig;
    }

    public override void Enter()
    {
        base.Enter();

        View.StartAirborne();
        Data.Speed = _config.Speed;
    }

    public override void Exit()
    {
        base.Exit();

        View.StopAirborne();
    }

    public override void Update()
    {
        base.Update();

        Data.YVelocity -= GetGravityMultipliyer() * Time.deltaTime;
    }

    protected virtual float GetGravityMultipliyer() => _config.BaseGravity;
}
