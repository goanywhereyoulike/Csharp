using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public List<PlayerObject> players;
    public List<EnemyObject> enemies;
    public List<EnemyMeleeObject> meleeEnemies;
    public List<EnemyRangedObject> rangeEnemies;
    private string[] pName = { "Oliver", "George", "Harry", "Jack", "Thomas", "Leo" , "Teddy", "Teddy", "David" };
    private string[] dName = { "Steve Austin", "Arnold Etchison", "Max Crandall", "Tex Thompson", "Lonnie Machin", "Angelo Bend" };


    void Awake()
    {

        for (int i = 0; i<2;i++)
        {
            CreatePlayerObject();
        }

        for (int i = 0; i < 5; i++)
        {
            //CreateEnemyObject();
            CreateMeleeEnemyObject();
            CreateRangedEnemyObject();
        }
  
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CreatePlayerObject()
    {
        PlayerObject p = new PlayerObject(Random.Range(0, 1000),pName[Random.Range(0, pName.Length)], dName[Random.Range(0, dName.Length)], Random.Range(0.0f, 10.0f), new Vector3(Random.Range(0, 9), 1, Random.Range(0, 9)));
        //p.ID = Random.Range(0, 1000);
        //p.playerName = pName[Random.Range(0, pName.Length)];
        //p.speed = Random.Range(0.0f, 10.0f);
        //p.position = new Vector3(Random.Range(0, 9), Random.Range(0, 9), Random.Range(0, 9));
        //p.displayName = dName[Random.Range(0, dName.Length)];
        ICombat combatobj = p;
        players.Add(p);

    }

    //public void CreateEnemyObject()
    //{
    //    EnemyMeleeObject EM = new EnemyMeleeObject(Random.Range(0, 1000), dName[Random.Range(0, dName.Length)], Random.Range(10, 100), Random.Range(0, 10), Random.Range(0.0f, 10.0f), new Vector3(Random.Range(0, 9), Random.Range(0, 9), Random.Range(0, 9)), Random.Range(0, 10));
    //    EnemyRangedObject ER = new EnemyRangedObject(Random.Range(0, 1000), dName[Random.Range(0, dName.Length)], Random.Range(10, 100), Random.Range(0, 10), Random.Range(0.0f, 10.0f), new Vector3(Random.Range(0, 9), Random.Range(0, 9), Random.Range(0, 9)), Random.Range(0, 10));
    //    enemies.Add(EM);
    //    enemies.Add(ER);
    //}
    public void CreateMeleeEnemyObject()
    {
        EnemyMeleeObject EM = new EnemyMeleeObject(Random.Range(0, 1000), dName[Random.Range(0, dName.Length)], Random.Range(10, 100), Random.Range(0, 10), Random.Range(0.0f, 10.0f), new Vector3(Random.Range(0, 9), 1, Random.Range(0, 9)), Random.Range(0, 10));
        //EM.ID = Random.Range(0, 1000);
        //EM.displayName = dName[Random.Range(0, dName.Length)];
        //EM.damage = Random.Range(0, 10);
        //EM.speed = Random.Range(0.0f, 10.0f);
        //EM.position = new Vector3(Random.Range(0, 9), Random.Range(0, 9), Random.Range(0, 9));
        EnemyMeleeObject EM2 = EM;
        enemies.Add(EM2);
        meleeEnemies.Add(EM);
        
    }


    public void CreateRangedEnemyObject()
    {
       EnemyRangedObject ER = new EnemyRangedObject(Random.Range(0, 1000), dName[Random.Range(0, dName.Length)], Random.Range(10, 100), Random.Range(0, 10), Random.Range(0.0f, 10.0f), new Vector3(Random.Range(0, 9), 1, Random.Range(0, 9)), Random.Range(0, 10));
        //ER.ID = Random.Range(0, 1000);
        //ER.displayName = dName[Random.Range(0, dName.Length)];
        //ER.damage = Random.Range(0, 10);
        //ER.speed = Random.Range(0.0f, 10.0f);
        //ER.position = new Vector3(Random.Range(0, 9), Random.Range(0, 9), Random.Range(0, 9));
        EnemyRangedObject ER2 = ER;
        enemies.Add(ER2);
        rangeEnemies.Add(ER);
      

    }


}
