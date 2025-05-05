using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{


    public GameObject pauseMenu = null;
    private bool isPaused = false;
    private void Start()
    {
        if (pauseMenu!=null)
        {
            pauseMenu.SetActive(false);
        }
        isPaused = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Resume()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pauseMenu.SetActive(isPaused);
    }
    public void returnMenu()
    {
        SceneManager.LoadScene("Start Scene");
    }
}
