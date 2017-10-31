using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path {

    List<Node> _path;
    float _cost;

    public Path(List<Node> path,float cost)
    {
        _cost = cost;
        _path = path;
    }

    public float GetCost()
    {
        return _cost;
    }

    public Node Pop()
    {
        if (_path.Count == 0)
            return null;
        _cost -= _path[0]._cost;
        Node node = _path[0];
        _path.RemoveAt(0);
        return node;
    }
}
