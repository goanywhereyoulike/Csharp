using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyMeleeObject : EnemyObject
{
    public int defend;
    public EnemyMeleeObject(int newId, string newDisplayname, int newHp, int newDamage, float newSpeed, Vector3 newPosition, int newDefend) : base(newId, newDisplayname, newHp, newDamage, newSpeed, newPosition)
    {
        defend = newDefend;
    }
}
