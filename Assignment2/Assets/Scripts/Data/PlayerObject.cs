using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerObject : BaseObject, ICombat,IDamagable
{
    public string playerName;
    [SerializeField]
    private int _hp= 100;
    public int hp { get { return _hp; } set { _hp = value; } }
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
        _hp -= dam;
        return 0;
    }
}
