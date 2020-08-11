using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerObject : BaseObject, ICombat,IDamagable
{
    public string playerName;
    public int hp { get; set; }
    public int damage { get; set; }

    public PlayerObject(int newID, string newUsername, string newDisplayname, float newSpeed, Vector3 newPosition)
    {
        ID = newID;
        displayName = newDisplayname;
        playerName = newUsername;
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
