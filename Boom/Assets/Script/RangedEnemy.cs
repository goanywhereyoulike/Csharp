using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemies
{
    [SerializeField]
    public float range;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    public float bulletSpeed;
    float fireRate;
    float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position,target.position)>range && health>maxHealth/2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            /*GameObject m_bullet = Instantiate(bullet, transform);
            m_bullet.GetComponent<Rigidbody2D>().velocity = target.position * bulletSpeed;*/
            CheckIfTimeToFire();
        }
        if (!isAlive())
        {
            emcr.enemiesKilled++;
            GameObject effect = Instantiate(Deadeffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.4f);
            Destroy(gameObject);


        }
        //if (emcr.enemiesKilled == 4)
        //{
        //    Time.timeScale = 0;
        //}
    }
    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire && Time.time>1)
        {
            GameObject m_bullet = Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
            m_bullet.GetComponent<Rigidbody2D>().velocity = target.position * bulletSpeed;
        }

    }
}
