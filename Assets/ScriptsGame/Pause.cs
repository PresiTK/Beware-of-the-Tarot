using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public CharacterMovement characterMovement; // Asigna aquí el script de movimiento del personaje
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
        characterMovement.paused = !characterMovement.paused; // Asegúrate de que el movimiento del personaje no esté pausado al inicio

    }
    public void returnMenu()
    {
        SceneManager.LoadScene("Start Scene");
    }
}
