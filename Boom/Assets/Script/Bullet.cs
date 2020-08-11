using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour   
{
    [SerializeField]
    public int damage;
    public GameObject hiteffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           collision.gameObject.GetComponent<Enemies>().TakeDamage(damage);
        }
            GameObject effect= Instantiate(hiteffect, transform.position, Quaternion.identity);

       Destroy(effect, 0.4f);
       Destroy(gameObject);

    }

   
}
