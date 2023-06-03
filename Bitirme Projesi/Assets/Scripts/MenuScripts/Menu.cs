using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject fadeScreen,cutText, skipButton;
    private int sceneIndex;
    private void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneIndex = currentScene.buildIndex;

        if (sceneIndex != 0 )
        {
            StartCoroutine(StartCutScene());
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame()
    {
        StartCoroutine(StartCutScene());
    }

    IEnumerator StartCutScene()
    {
        fadeScreen.SetActive(true);

        yield return new WaitForSeconds(1.3f);

        cutText.SetActive(true);

        yield return new WaitForSeconds(3f);

        skipButton.SetActive(true);
    }

    public void SkipButton()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
