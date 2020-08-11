using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable 
{
    float speed { get; set; }
    Vector3 position { get; set; }
    int MoveTo(Vector3 newPos);
}
