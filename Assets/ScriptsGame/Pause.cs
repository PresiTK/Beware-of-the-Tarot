using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{


    public GameObject pauseMenu = null;
    private bool isPaused;
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
}
