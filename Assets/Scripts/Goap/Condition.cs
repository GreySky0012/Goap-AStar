using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition {

    protected List<string> _contextTypes;
    protected List<Context> _contexts;

	public Condition()
    {
        _contextTypes = new List<string>();
        _contexts = null;
    }

    public abstract bool Check();

    public abstract bool ReCheck();
}