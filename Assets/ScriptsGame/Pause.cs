using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{


    [SerializeField] GameObject pauseMenu = null;
    bool isPaused;
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
        if (Input.GetKeyDown(KeyCode.Escape)&&pauseMenu!=null)
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseMenu.SetActive(isPaused);
        }
    }
}
