using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : FSMState
{
    Agent _agent;

    public IdleState(FSMState back,Agent agent) : base(back)
    {
        _agent = agent;
    }

    public override FSMState Execute()
    {
        Goal goal;
        if((goal = _agent.PopGoal())!= null)
        {
            Queue<Action> todo;
            if((todo = Planner.Plan(_agent.Actions(), goal)) != null)
            {
                return new ActState(todo, _agent, goal, null);
            }
        }

        return this;
    }
}
