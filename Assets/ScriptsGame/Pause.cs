using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{


    public GameObject pauseMenu = null;
    public GameObject boton1;
    public GameObject boton2;
    private bool isPaused = false;
    private void Start()
    {
        if (pauseMenu!=null)
        {
            pauseMenu.SetActive(false);
        }
        isPaused = false;
        boton1.SetActive(true);
        boton2.SetActive(true);
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
