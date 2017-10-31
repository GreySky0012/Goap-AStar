using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action {

    List<Condition> _considtions;
    float _cost;

    public bool Check()
    {
        foreach (Condition c in _considtions)
        {
            if (!c.Check())
                return false;
        }
        return true;
    }

    public abstract bool Execute(Agent agent);

    public virtual float GetCost()
    {
        return _cost;
    }
}
