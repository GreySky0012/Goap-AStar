using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActState : FSMState {

    Queue<Action> _todo;
    Agent _agent;
    Goal _goal;
    Action _currentAction;

    public ActState(Queue<Action> actions,Agent agent,Goal goal ,FSMState back) : base(back)
    {
        _currentAction = null;
        _todo = actions;
        _agent = agent;
        _goal = goal;
        if (_todo.Count != 0)
            _currentAction = _todo.Dequeue();
    }

    public override FSMState Execute()
    {
        if(_currentAction == null)
        {
            if (_todo.Count == 0)
            {
                if (_back != null)
                    return _back;
                return new IdleState(null, _agent);
            }
            _currentAction = _todo.Dequeue();
        }

        if (!_currentAction.Check())
        {
            return new RePlanState(null, _agent, _goal);
        }
        if (_agent.Execute(_currentAction))
            _currentAction = _todo.Dequeue();
        return this;
    }
}
