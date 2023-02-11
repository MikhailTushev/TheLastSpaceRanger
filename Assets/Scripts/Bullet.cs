using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatisSolid;

    [SerializeField] bool enemyBull;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distance, whatisSolid);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Enemy") && !enemyBull)
            {
                hit.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            if (hit.collider.CompareTag("Player") && enemyBull)
            {
                HealthSystem.health -= damage;
            }
            if (hit.collider.CompareTag("Solid"))
            {
                Destroy(gameObject);
            }

            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject, lifetime);
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
