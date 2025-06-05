using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject teclas;
    private bool ended = false;
    private void Start()
    {
        teclas.SetActive(false);
    }
    private void Update()
    {
        if (ended)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("CreditScene");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ended = true;
            teclas.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ended = false;
            teclas.SetActive(false);
        }
    }
}
