using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour {

    public float _speed;
    [HideInInspector]
    public bool _isWalking = false;

    private Path _path;
    private Vector2 _currentAim;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_isWalking)
        {
            if (MoveByStep())
            {
                Node _currentNode = _path.Pop();
                if (_currentNode == null)
                {
                    _isWalking = false;
                }
                else
                    _currentAim = _currentNode.transform.position;
            }
        }
    }

    private bool MoveByStep()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _currentAim, step);
        return new Vector2(transform.position.x, transform.position.y).Equals(_currentAim);
    }

    public void Walk(Path path)
    {
        if(path == null)
        {
            return;
        }
        _path = path;
        _isWalking = true;
        _currentAim = transform.position;
    }
}