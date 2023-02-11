using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    Transform player1;

    public GunType type;
    public float offset;
    public GameObject bullet;
    public Transform shotpoint;
    public bool boss;

    [SerializeField]
    float agroRange;

    private float timebtwshoot;
    public float startTimeshot;

    private PlayerController player;
    private Enemy enemy;

    public enum GunType { Default, Enemy };

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        enemy = FindObjectOfType<Enemy>().GetComponent<Enemy>();
    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player1.position);

        if (distToPlayer < agroRange && type == GunType.Enemy)
        {
            Vector3 vector = player.transform.position - transform.position;
            float roz2 = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, roz2 + offset);
            if (boss)
            {
                if (enemy.health <= 70 && enemy.health > 20)
                {
                    agroRange = 7;
                    enemy.agroRange = 5;
                    enemy.speed = 3;
                    if (timebtwshoot <= 0)
                    {
                        StartCoroutine(Shoting());
                    }
                }

                else if (enemy.health <= 20)
                {
                    agroRange = 8;
                    enemy.speed = 4; enemy.agroRange = 6;

                    if (timebtwshoot <= 0)
                    {
                        Invoke("Shot", 3);
                    }
                }

                else if (timebtwshoot <= 0 && enemy.health > 50)
                {
                    Shot();
                }

                timebtwshoot -= Time.deltaTime;

            }
            else
            {
                if (timebtwshoot <= 0)
                {
                    Shot();
                }
                timebtwshoot -= Time.deltaTime;
            }

        }
        if (type == GunType.Default)
        {
            Vector3 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float roz2 = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, roz2 + offset);
            if (timebtwshoot <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                    Shot();
                }
            }

            else
            {
                timebtwshoot -= Time.deltaTime;
            }
        }
    }


    IEnumerator Shoting()
    {
        Shot();
        yield return new WaitForSeconds((float)0.3);
        Shot();
        yield return new WaitForSeconds((float)0.3);
        Shot();
        timebtwshoot = startTimeshot;
    }

    void Shot()
    {
        Instantiate(bullet, shotpoint.position, shotpoint.rotation);
        timebtwshoot = startTimeshot;
    }
}
