using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyObject :BaseObject,IDamagable
{
    [SerializeField]
    private int _hp;
    public int hp { get { return _hp; } set { _hp = value; } }
    public int damage { get; set; }
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
