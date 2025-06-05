using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScene : MonoBehaviour
{
    public bool CanContinue = false; // Variable para controlar si se puede continuar
    private bool canInteract = false; // Variable para controlar la interacción
    public CharacterMovement characterMovement; // Asigna aquí el script de movimiento del personaje
    public GameObject blocked;

    private void Start()
    {
        if (blocked != null)
        {
            blocked.SetActive(false);
        }
    }
    private void Update()
    {
        if (characterMovement.WinIsActive)
        {
            CanContinue = true;
        }
        // Verifica si se puede continuar y si el jugador está interactuando
        if (CanContinue && canInteract && Input.GetKeyDown(KeyCode.E))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            blocked.SetActive(true);
            canInteract = true; // Permitir interacción al entrar en el trigger
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            blocked.SetActive(false);
            canInteract = false;
        }
    }
}
