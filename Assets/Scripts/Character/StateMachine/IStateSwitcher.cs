using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateSwitcher
{
    void SwitchState<State>() where State : IState;
}
