using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState {

    protected FSMState _back;

    public FSMState(FSMState back)
    {
        _back = back;
    }

    public abstract FSMState Execute();

}
