using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour {

    List<Node> _riverNodes;

    public float _changeTime;

    float _restTime;

    private void Awake()
    {
        _restTime = _changeTime;
        _riverNodes = new List<Node>();
        GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node");
        foreach(GameObject node in nodes)
        {
            if (node.name.Equals("RiverNode"))
            {
                _riverNodes.Add(node.GetComponent<Node>());
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _restTime -= Time.deltaTime;
        if (_restTime <= 0)
        {
            ChangeRiver();
            _restTime = _changeTime;
        }
	}

    private void ChangeRiver()
    {
        Debug.Log("Change");
        float currentCost = _riverNodes[0]._cost == 1 ? 5 : 1;
        foreach (Node node in _riverNodes)
        {
            node._cost = currentCost;
        }
    }
}
