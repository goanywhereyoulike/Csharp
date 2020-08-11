using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject :IDataElement, IMoveable
{
    public int ID { get; set; }
    public string displayName { get; set; }
    public Vector3 position { get; set; }
    public float speed { get; set; }
    public int MoveTo(Vector3 newPos)
    {
        position = newPos;
        return 0;
    }
}
