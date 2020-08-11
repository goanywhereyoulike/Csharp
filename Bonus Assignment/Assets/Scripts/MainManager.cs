using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public GameObject rangeenmeyPrefab;
    public GameObject meleeenmeyPrefab;
    public GameObject playerPrefab;
    public GameObjectManager datamanager;
    [SerializeField]
    Text text;

    public List<RnageEnemyController> renemycontrollers;
    public List<EnemyController> enemycontrollers;
    public List<PlayerController> playcontrollers;
    // Start is called before the first frame update
    void Start()
    {
        if (datamanager == null)
        {
            datamanager.GetComponent<GameObjectManager>();

        }

         //CreateRangeEnemyInstance(datamanager.rangeEnemies);
         //CreateMeleeEnemyInstance(datamanager.meleeEnemies);
        CreateEnmeyInstance(datamanager.enemies);
        CreatePlayerInstance(datamanager.players);
        
    }

    void CreateEnmeyInstance(List<EnemyObject> enemies)
    {
        foreach(EnemyObject enemy in enemies)
        {
            GameObject enemyObj = null;
            if (enemy is EnemyRangedObject)
            {
                if (rangeenmeyPrefab != null)
                {
                    enemyObj = GameObject.Instantiate<GameObject>(rangeenmeyPrefab);
                    enemyObj.transform.position = enemy.position;
                    enemyObj.name = rangeenmeyPrefab.name + " " + enemy.ID;

                }
            }
            else if (enemy is EnemyObject)
            {
                if (meleeenmeyPrefab != null)
                {
                    enemyObj = GameObject.Instantiate<GameObject>(meleeenmeyPrefab);
                    enemyObj.transform.position = enemy.position;
                    enemyObj.name = meleeenmeyPrefab.name + " " + enemy.ID;

                }
            }
            if (enemyObj != null)
                {
                    EnemyController controller = enemyObj.GetComponent<EnemyController>();
                    if (controller != null)
                    {
                        controller.myenemy = enemy;
                        enemycontrollers.Add(controller);
                    }
                }
            

        }

    }


    void CreateRangeEnemyInstance(List<EnemyRangedObject> renemies)
    {
        foreach (EnemyRangedObject renemy in renemies)
        {
            if (renemy is EnemyRangedObject)
            {
                GameObject enemyObj = GameObject.Instantiate<GameObject>(rangeenmeyPrefab);
                enemyObj.transform.position = renemy.position;
                enemyObj.name = rangeenmeyPrefab.name + " " + renemy.ID;
                RnageEnemyController controller = enemyObj.GetComponent<RnageEnemyController>();
                if (controller != null)
                {
                    controller.myrangeenemy = renemy as EnemyRangedObject;
                    renemycontrollers.Add(controller);
                }
            }

        }

    }

    void CreateMeleeEnemyInstance(List<EnemyMeleeObject> menemies)
    {
        foreach (EnemyMeleeObject menemy in menemies)
        {
            if (menemy is EnemyMeleeObject)
            {
                GameObject enemyObj = GameObject.Instantiate<GameObject>(meleeenmeyPrefab);
                enemyObj.transform.position = menemy.position;
                enemyObj.name = meleeenmeyPrefab.name + " " + menemy.ID;
                MeleeEnemyController controller = enemyObj.GetComponent<MeleeEnemyController>();
                if (controller != null)
                {
                    controller.mymeleeenemy = menemy as EnemyMeleeObject;
                }
            }

        }



    }

    void CreatePlayerInstance(List<PlayerObject> players)
    {
        foreach (PlayerObject player in players)
        {
            if (player is PlayerObject)
            {
                GameObject playerObj = GameObject.Instantiate<GameObject>(playerPrefab);
                playerObj.transform.position = player.position;
                playerObj.name = playerPrefab.name + " " + player.ID;
                PlayerController controller = playerObj.GetComponent<PlayerController>();
                if (controller != null)
                {
                    controller.myplayer = player as PlayerObject;
                    playcontrollers.Add(controller);
                }
            }

        }



    }
    // Update is called once per frame
    void Update()
    {
       ClickToMove();
       ShowtheName();
    }

    void ClickToMove()
    {
       
        foreach (PlayerController playerController in playcontrollers)
        {
            if (playerController.myplayer is IMoveable)
            {

                playerController.isMoveable = true;

            }

        }

    }


   void ShowtheName()
    {
        foreach (PlayerController playerController in playcontrollers)
        {
            foreach (EnemyController enemyController in enemycontrollers)
            {
                if (playerController.myplayer is IMoveable)
                {
                    if (enemyController.myenemy is IAttackable)
                    {
                        
                            if (playerController.isMoveable == true)
                        {
                            if (playerController.myplayer.hp < 70)
                            {
                                text.text = "DisplayName: " + enemyController.myenemy.displayName + ", HP: " + enemyController.myenemy.hp;
                                Debug.Log("DisplayName: " + enemyController.myenemy.displayName + ", HP: " + enemyController.myenemy.hp);
                              
                            }
                        }
                    }
                }
            }
        }

    }


}
