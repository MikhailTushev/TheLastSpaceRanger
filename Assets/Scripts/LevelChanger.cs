using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    private Animator animator;
    public int levelToLoad;

    public Slider slider;
    public GameObject loadScreen;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   public void FadeToLevel()
   {
        animator.SetTrigger("fade");
   }

    public void OnFadeComplete()
    {
        StartCoroutine(LoadingScreenOnFade());

        Task.Delay(1000);
        SceneManager.LoadScene(levelToLoad);
    }

    IEnumerator LoadingScreenOnFade()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToLoad);
        loadScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
