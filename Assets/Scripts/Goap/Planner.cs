using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planner {

	public static Queue<Action> Plan(List<Action> actions,Goal goal)
    {
        List<Action> availableActions = new List<Action>();
        actions.ForEach(delegate (Action a) { if (a.Check()) availableActions.Add(a); });



        return null;
    }

    private static void Plan(List<Action> actions,Goal goal,List<Context> environment)
    {

    }
}
