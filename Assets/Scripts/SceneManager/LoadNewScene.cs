using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    public string nextSceneName;
    //public int nextSceneIndex;    Alternative way to store scenes

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
        SceneManager.LoadScene(nextSceneName);          //Loads the next level, specified by Scene Name.


        //We can use the alternative method below, if we want to just use a numbering system. Might be easier to organize. =)

        //SceneManager.LoadScene(nextSceneIndex);         //Loads the next level, specified by Scene Index.
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
        //SceneManager.LoadScene("Level 1");    //This was the original code for this function.

        SceneManager.LoadScene(playerController.getActiveScene);        
        //I haven't tested this yet, but load Level One and fail on purpose to get to the GameOver Scene And See if This Works. =)
    }

    public void ExitGame()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }
    
}
