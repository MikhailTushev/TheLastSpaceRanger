using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MoneyText.coins += 1;
            PlayerPrefs.SetInt("coins", MoneyText.coins);
            Destroy(gameObject);
        }
    }
}
