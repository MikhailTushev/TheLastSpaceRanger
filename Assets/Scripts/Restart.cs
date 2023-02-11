using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public SceneManager manager;
    public GameObject panel;

    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
            panel.SetActive(false);
        }
    }
}
