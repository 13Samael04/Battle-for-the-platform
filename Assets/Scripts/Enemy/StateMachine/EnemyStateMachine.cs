using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyStateMachine : IStateSwitcher
{
    private List<IState> _state;
    private IState _currentState;

    public EnemyStateMachine(Enemy enemy)
    {
        StateMachineData data = new StateMachineData();

        _state = new List<IState>()
        {
            /*new IdlingState(this, data, character),
            new RunningState(this, data, character),
            new JumpingState(this, data, character),
            new FallingState(this, data, character)*/
        };

        _currentState = _state[0];
        _currentState.Enter();
    }

    public void SwitchState<State>() where State : IState
    {
        IState state = _state.FirstOrDefault(state => state is State);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update() => _currentState.Update();
}
