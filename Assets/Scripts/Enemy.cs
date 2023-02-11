using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    public float agroRange;

    Rigidbody2D rb;

    private float timebtwshoot = 0;
    public float startTimeshot;

    public int health;
    public float speed;

    public GameObject bosspanel;
    public int damage;
    public bool boss;
    private Animator anim;
    private PlayerController player1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player1 = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }


        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange)
        {
            anim.SetBool("isRun", true);
            ChasePlayer();
        }
        else
        {
            anim.SetBool("isRun", false);
            StopChasePlayer();
        }

        if (health <= 0 && boss)
        {
            bosspanel.SetActive(true);
        }
    }

    
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (timebtwshoot <= 0)
            {
                anim.SetTrigger("enemyAttack");
                timebtwshoot = startTimeshot;
            }
            else
            {
                timebtwshoot -= Time.deltaTime;
            }
        }
    }

    public void OnEnemyAttack()
    {
        HealthSystem.health -= damage;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void ChasePlayer()
    {
        if (player1.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        transform.position = Vector2.MoveTowards(transform.position, player1.transform.position, speed * Time.deltaTime);
    }

    void StopChasePlayer()
    {
        rb.velocity = new Vector2(0, 0);
    }
}
