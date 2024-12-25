using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject gameOverScreen;
    public static bool isPaused;
    [SerializeField] Animator animationTransition;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }

    public void RestartGame()
    {
        StartCoroutine(RestartLevel());
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }

    public void SettingsMenu()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Back()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        StartCoroutine(ExitLevel());
    }

    IEnumerator ExitLevel()
    {
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        animationTransition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        SceneManager.LoadScene("MainMenu");
        animationTransition.SetTrigger("Start");
    }

    IEnumerator RestartLevel()
    {
        animationTransition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Play");
        animationTransition.SetTrigger("Start");
    }
}
