using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyRangedObject : EnemyObject, IAttackable
{
    public float range { get; set; }
    public EnemyRangedObject(int newId, string newDisplayname, int newHp, int newDamage, float newSpeed, Vector3 newPosition, float newRange) : base(newId, newDisplayname, newHp, newDamage, newSpeed, newPosition)
    {
        range = newRange;
    }
    public int Attack(IDamagable damagable)
    {
        damagable.TakeHit(damage);
        return 0;
    }
    public bool CheckRangeTo(IMoveable moveable)
    {
        if ((position - moveable.position).magnitude <= range)
        {
            return true;
        }
        return false;
    }

}
