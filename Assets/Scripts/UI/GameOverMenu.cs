using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Intro");
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("exit");
    }
}
