using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    public string nextSceneName;
    public SceneName sceneName;

    public string gameOverScene;

    public GameObject creditsPanel;
    public GameObject creditsText;

    public PlayerController playerController;

    public void StartGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void LoadCredits()
    {
        creditsPanel.SetActive(true);
        creditsText.SetActive(true);
    }

    public void UnloadCredits()
    {
        creditsPanel.SetActive(false);
        creditsText.SetActive(false);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(gameOverScene);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneName.sceneName);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }
    
}
