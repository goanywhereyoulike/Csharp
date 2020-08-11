using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    bool canTakeDamage = true;
    public GameObject Deadeffect;
    public GameObject Hurteffect;
    public int maxHealth = 100;
    public int curHealth;
    public Healthbar healthbar;
    public Text Gameovertext;
    //public Text ScoreDisplay;
    public GameObject battleeffect;
    public GameObject GameOvereffect;
    public GameObject PauseManu;
    public int EnemyKilledNum = 4;
    public EnemyController enemycontroller;
    public GameObject effect2;
    //public int score = 0;
    public Animator animator;
    //public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        //score = 0;
        //ScoreDisplay.text =  "Score: " + score.ToString();
        Gameovertext.text = "";
        //position = new Vector3(-278,395,0);
        effect2 = Instantiate(battleeffect, transform.position, Quaternion.identity);
        curHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.SetHealth(curHealth);
        //ScoreDisplay.text = "Score: " + score.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        if (enemycontroller.enemiesKilled == EnemyKilledNum)
        {
            Destroy(effect2);
            
          
        }
        if (!isAlive())
        {
            Destroy(effect2);
            GameObject effect = Instantiate(Deadeffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.4f);
            Destroy(gameObject);
            Gameovertext.text = "Game Over";
            PauseManu.SetActive(true);
            Instantiate(GameOvereffect, transform.position, Quaternion.identity);
            Time.timeScale = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("IsDamage");
        curHealth -= damage;
        if (curHealth > 0)
        {
            GameObject effect = Instantiate(Hurteffect, transform.position, Quaternion.identity);
           // Destroy(effect, 0.4f);
        }
        healthbar.SetHealth(curHealth);
        

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if (canTakeDamage)
            {
                StartCoroutine(WaitForSeconds());
                TakeDamage(5);
                
            }
        }
    }
    IEnumerator WaitForSeconds()
    {
        
        canTakeDamage = false;
        yield return new WaitForSecondsRealtime(0.5f);
        canTakeDamage = true;
    }
   public bool isAlive()
    {
        if(curHealth<=0)
        {
            return false;
        }
        return true;
    }
    public void save()
    {
        Vector3 playerPosition = transform.position;
        int health = curHealth;
        int score = enemycontroller.score;
        PlayerSavObj savedPlayer = new PlayerSavObj
        {
            score = score,
            plyerPosition = playerPosition,
            health = health
        };
        string json = JsonUtility.ToJson(savedPlayer);
        File.WriteAllText(Application.dataPath + "/save.txt", json);
        
    }
    public void load()
    {
        if(File.Exists(Application.dataPath+"/save.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
            PlayerSavObj saveobj = JsonUtility.FromJson<PlayerSavObj>(saveString);

            transform.position = saveobj.plyerPosition;
            curHealth = saveobj.health;
            enemycontroller.score = saveobj.score;
        }
        else
        {
            Debug.Log("Load Failed");
        }

    }
}

public class PlayerSavObj
{
    public int score;
    public int health;
    public Vector3 plyerPosition;
}