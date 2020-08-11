using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BaseGame: BaseData
{
    public int start_Value;
    public int avatar_Choices;
    public int levelNum;
    public int obstacles_Num;
    public List<Vector3> spawnPosition= new List<Vector3>();
    public List<Enemy> enemies;
    public List<Player> players;

    public BaseGame()
    {

      enemies = new List<Enemy>();
        players = new List<Player>();


    }
}
