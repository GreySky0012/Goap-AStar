using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map{

    int _column;
    int _row;
    
    Node[,] _nodes;

    public Map(int column,int row,List<Node> nodes)
    {
        _column = column;
        _row = row;
        _nodes = new Node[column, row];

        foreach(Node node in nodes)
        {
            _nodes[(int)node._position.x, (int)node._position.y] = node;
        }
    }

    public Path SearchWay(Vector2 position, Vector2 aim)
    {
        List<Node> path = new List<Node>();
        SearchNode[,] map = new SearchNode[_column, _row];
        List<SearchNode> nodeStack = new List<SearchNode>();

        for (int i = 0; i < _column; i++)
            for (int h = 0; h < _row; h++)
                map[i, h] = new SearchNode(_nodes[i, h]);

        nodeStack.Add(map[(int)position.x, (int)position.y]);

        map[(int)position.x, (int)position.y]._realCost = 0;
        map[(int)position.x, (int)position.y]._cost = Estimate(map[(int)position.x, (int)position.y], map[(int)aim.x, (int)aim.y]);

        return SearchWay(map[(int)aim.x,(int)aim.y],map,nodeStack);
    }

    private Path SearchWay(SearchNode aim, SearchNode[,] map,List<SearchNode> nodeStack)
    {
        if(nodeStack.Count == 0)
        {
            return null;
        }
        nodeStack.Sort();
        SearchNode currentNode = nodeStack[0];
        List<SearchNode> neighbours = GetNeighbours(map,currentNode);
        foreach (SearchNode node in neighbours)
        {
            if (node.Equals(aim))
            {
                aim._previous = currentNode;
                aim._realCost = currentNode._realCost + node._node._cost;
                return aim.GetPath();
            }
            float currentCost = currentNode._realCost;
            currentCost += node._node._cost;
            currentCost += Estimate(node, aim);
            if(node._cost == -1||node._cost>currentCost)
            {
                node._cost = currentCost;
                node._realCost = currentNode._realCost + node._node._cost;
                if (!nodeStack.Contains(node))
                {
                    nodeStack.Add(node);
                }
                node._previous = currentNode;
            }
        }
        nodeStack.RemoveAt(0);
        return SearchWay(aim, map, nodeStack);
    }

    private float Estimate(SearchNode position,SearchNode aim)
    {
        float result = Math.Abs(aim._node._position.x - position._node._position.x);
        return result + Math.Abs(aim._node._position.y - position._node._position.y);
    }

    private Node GetNode(int x,int y)
    {
        return _nodes[x, y];
    }

    private SearchNode GetNode(SearchNode[,] map,int x,int y)
    {
        if (x >= 0 && x < _column && y >= 0 && y < _row)
            return map[x, y];
        return null;
    }

    private List<SearchNode> GetNeighbours(SearchNode[,] map, SearchNode node)
    {
        List<SearchNode> neighbours = new List<SearchNode>();

        int x = (int)node._node._position.x,y = (int)node._node._position.y;

        SearchNode currentNode;

        if ((currentNode = GetNode(map, x - 1, y)) != null)
            neighbours.Add(currentNode);
        if ((currentNode = GetNode(map, x + 1, y)) != null)
            neighbours.Add(currentNode);
        if ((currentNode = GetNode(map, x, y - 1)) != null)
            neighbours.Add(currentNode);
        if ((currentNode = GetNode(map, x, y + 1)) != null)
            neighbours.Add(currentNode);

        return neighbours;
    }

    private class SearchNode : IComparable
    {
        public Node _node;
        public float _cost;
        public float _realCost;

        public SearchNode _previous;

        public SearchNode(Node node)
        {
            _node = node;
            _cost = -1;
            _previous = null;
        }

        public Path GetPath()
        {
            List<Node> path = new List<Node>();
            path.Add(_node);
            SearchNode node = this;
            while (node._previous != null)
            {
                node = node._previous;
                path.Add(node._node);
            }
            path.Reverse();

            Path p = new Path(path, _realCost);

            return p;
        }

        public int CompareTo(object obj)
        {
            SearchNode node = (SearchNode)obj;
            return _cost.CompareTo(node._cost);
        }

        public bool Equals(SearchNode node)
        {
            return node._node._position.Equals(_node._position);
        }
    }
}