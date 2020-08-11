using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Player player;
    public int enemiesKilled = 0;
    public int EnemykilledNum = 4;
    public Text YouWintext;
    public GameObject YouWineffect;
    public GameObject PauseManu;
    public Button nextlevel;
    public int score=0;
    public Text ScoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        enemiesKilled = 0;
        YouWintext.text = "";
        ScoreDisplay.text = "Score : " + score.ToString();
    }


    // Update is called once per frame
    void Update()
    { 
        ScoreDisplay.text = "Score : " + score.ToString();
        if (enemiesKilled == EnemykilledNum)
        {
            //Destroy(player.effect2);
            Destroy(gameObject);
            YouWintext.text = "You Win";
            Instantiate(YouWineffect, transform.position, Quaternion.identity);
            PauseManu.SetActive(true);
            
            Time.timeScale = 0;

        }

        
    }
}
