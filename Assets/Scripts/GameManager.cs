using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    private Map _map;

    public int _mapColumn;
    public int _mapRow;

    private Vector2 _currentAim;

    private Walker _sphere;

    public static GameManager GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
        _currentAim = new Vector2(3, 5);
        _sphere = GameObject.FindGameObjectWithTag("Sphere").GetComponent<Walker>();
    }

    // Use this for initialization
    void Start () {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Node");
        List<Node> nodes = new List<Node>();
        foreach(GameObject node in objects)
        {
            nodes.Add(node.GetComponent<Node>());
        }
        _map = new Map(_mapColumn, _mapRow,nodes);
	}
	
	// Update is called once per frame
	void Update () {
        if (!_sphere._isWalking)
        {
            Vector2 position = _currentAim;
            ChangeAim();
            _sphere.Walk(_map.SearchWay(position,_currentAim));
        }
	}

    private void ChangeAim()
    {
        if(_currentAim.Equals(new Vector2(3, 0)))
        {
            _currentAim = new Vector2(3, 5);
        }
        else
        {
            _currentAim = new Vector2(3, 0);
        }
    }
}
