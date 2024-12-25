using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject startButton;
    public GameObject exitButton;
    public GameObject settingsButton;
    public GameObject settingsMenu;
    public GameObject mainText;
    [SerializeField] Animator animationTransition;

    void Start()
    {
        settingsMenu.SetActive(false);
    }
    public void PlayGame()
    {
        StartCoroutine(LoadLevel());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SettingsMenu()
    {
        mainText.SetActive(false);
        startButton.SetActive(false);
        exitButton.SetActive(false);
        settingsButton.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Back()
    {
        mainText.SetActive(true);
        startButton.SetActive(true);
        exitButton.SetActive(true);
        settingsButton.SetActive(true);
        settingsMenu.SetActive(false);
    }

    IEnumerator LoadLevel()
    {
        animationTransition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Play");
        animationTransition.SetTrigger("Start");
    }
}
