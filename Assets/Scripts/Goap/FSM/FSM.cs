using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM {

    FSMState _state;

	public FSM(FSMState state)
    {
        _state = state;
    }

    public void Execute()
    {
        _state = _state.Execute();
    }
}
