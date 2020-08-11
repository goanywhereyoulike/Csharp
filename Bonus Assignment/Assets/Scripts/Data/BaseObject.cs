using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject :IDataElement, IMoveable
{
    public int ID { get; set; }
    [SerializeField]
    private string _displayName;
    public string displayName { get { return _displayName; } set { _displayName = value; } }

    [SerializeField]
    private Vector3 _position;
    public Vector3 position { get { return _position; } set { _position = value; } }

    [SerializeField]
    private float _speed=10;
    public float speed { get { return _speed; } set { _speed = value; } }
    public int MoveTo(Vector3 newPos)
    {
        
        _position = newPos;
        return 0;
    }
}
