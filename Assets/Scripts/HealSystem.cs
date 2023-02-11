using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSystem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (HealthSystem.health < 3)
            {
                HealthSystem.health += 1;
                Destroy(gameObject);
            }
        }
    }
}
