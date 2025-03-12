using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject GameOver;

    private void Start()
    {
        GameOver.SetActive(false);
    }
    public void GameOverMenu()
    {
        GameOver.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Eloi Scene");
    }
    public void returnMenu()
    {
        SceneManager.LoadScene("Start Scene");
    }
}
