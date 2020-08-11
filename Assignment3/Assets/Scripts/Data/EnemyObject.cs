using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject :BaseObject,IDamagable
{
    public int damage { get; set; }
    public int hp { get; set; }

    public EnemyObject (int newId,string newDisplayname, int newHp, int newDamage, float newSpeed, Vector3 newPosition)
    {
        ID = newId;
        hp = newHp;
        damage = newDamage;
        displayName = newDisplayname;
        speed = newSpeed;
        position = newPosition;

    }

    public int CauseDamage(ICombat opponent)
    {
        return 0;
    }
    public int TakeHit(int dam)
    {
        hp -= damage;
        return 0;
    }
}
