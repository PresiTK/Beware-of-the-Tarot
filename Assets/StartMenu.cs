using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
