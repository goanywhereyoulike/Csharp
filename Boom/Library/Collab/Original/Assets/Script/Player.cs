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
    public GameObject battleeffect;
    public GameObject GameOvereffect;
    public GameObject PauseManu;

    public EnemyController enemycontroller;
    public GameObject effect2;
    public Animator animator;
    //public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        Gameovertext.text = "";
        //position = new Vector3(-278,395,0);
        effect2 = Instantiate(battleeffect, transform.position, Quaternion.identity);
        curHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        if (enemycontroller.enemiesKilled == 4)
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
}
