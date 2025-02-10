using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinProgram : MonoBehaviour
{
    [SerializeField] GameObject winmenu = null;
    private bool win = false;
    private bool menu = false;
    private bool wining = false;
    private void Start()
    {
        if (winmenu != null)
        {
            winmenu.SetActive(false);
        }
        menu = false;
    }
    private void Update()
    {
        if (win && Input.GetKeyDown(KeyCode.E)) 
        {
            menu = true;
            Time.timeScale = menu ? 0 : 1;
            winmenu.SetActive(menu);
            wining = true;
        }
        if (wining && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Presi Scene");
            menu = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            win = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        win = false;
    }

}
