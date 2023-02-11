using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    [SerializeField]
    GameObject pause;

    [SerializeField]
    GameObject shop;
    void Start()
    {
        pause.SetActive(false);
        shop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void PauseOff()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { }
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    
    public void ShopOn()
    {
        shop.SetActive(true);
        Time.timeScale = 0;
    }

    public void ShopOff()
    {
        shop.SetActive(false);
        Time.timeScale = 0;
    }
}
