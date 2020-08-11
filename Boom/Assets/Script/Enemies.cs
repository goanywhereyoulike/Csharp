using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField]
    public int EnemykilledNum = 4;
    public int maxHealth;
    public int health;
    public GameObject Deadeffect;
    public Animator animator;
    [SerializeField]
    public float speed;
    public Player player;
    public EnemyController emcr;
    public Healthbar healthbar;

    public Transform target;
    public void TakeDamage(int d)
    {
        health -= d;
        animator = GetComponent<Animator>();
        animator.SetTrigger("IsDamage");
        healthbar.SetHealth(health);
    }
    public bool isAlive()
    {
        if (health <= 0)
        {
            return false;
        }
        return true;
    }
    // Start is called before the first frame update
    private void Start()
    {
        healthbar.SetMaxHealth(maxHealth);
        health = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth / 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            Vector2 moveDir = transform.position - player.transform.position;

            transform.Translate(moveDir.normalized * speed * Time.deltaTime);
        }
        if (!isAlive())
        {
            emcr.score += 10;
            //player.ScoreDisplay.text = "Score: " + player.score.ToString();
            emcr.enemiesKilled++;
            GameObject effect = Instantiate(Deadeffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.4f);
            Destroy(gameObject);
            
        }
        if (emcr.enemiesKilled == EnemykilledNum)
        {
            Time.timeScale = 0;
        }


    }
}