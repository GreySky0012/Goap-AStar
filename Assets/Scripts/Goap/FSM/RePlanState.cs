using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePlanState : FSMState {

    Goal _goal;
    Agent _agent;

    public RePlanState(FSMState next, Agent agent,Goal goal):base(next)
    {
        _agent = agent;
    }

    public override FSMState Execute()
    {
        Queue<Action> actions = Planner.Plan(_agent.Actions(), _goal);
        if (actions == null)
            return new IdleState(null, _agent);
        return new ActState(actions, _agent, _goal, null);
    }
}