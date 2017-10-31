using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

    FSM fsm;

    Queue<Goal> _goals;

    List<Action> _actions;

	// Use this for initialization
	void Start () {

        fsm = new FSM(new IdleState(null,this));
	}
	
	// Update is called once per frame
	void Update () {
        fsm.Execute();
	}

    public bool Execute(Action action)
    {
        return action.Execute(this);
    }

    public List<Action> Actions()
    {
        return _actions;
    }

    public void Reset()
    {
        _goals.Clear();
    }

    public void AddGoal(Goal goal)
    {
        _goals.Enqueue(goal);
    }

    public Goal PopGoal()
    {
        if (_goals.Count != 0)
            return _goals.Dequeue();
        return null;
    }
}