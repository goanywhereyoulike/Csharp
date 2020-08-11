using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable 
{
    Vector3 position { get; set; }
    int damage { get; set; }
    float range { get; set; }
    int Attack(IDamagable damagable);
    bool CheckRangeTo(IMoveable moveable);
}
