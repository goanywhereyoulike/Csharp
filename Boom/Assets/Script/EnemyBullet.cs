using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    [SerializeField]
    public int damage;
    public GameObject hiteffect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameObject effect = Instantiate(hiteffect, transform.position, Quaternion.identity);

            Destroy(effect, 0.4f);
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);

            GameObject effect = Instantiate(hiteffect, transform.position, Quaternion.identity);

            Destroy(effect, 0.4f);
            Destroy(gameObject);
        }
    }
}
