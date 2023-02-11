using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
            MoneyText.coins = PlayerPrefs.GetInt("coins", 0);
        }
    }
}
