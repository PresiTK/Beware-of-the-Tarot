using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMenu : MonoBehaviour
{
    public GameObject teclas;
    private bool canInteract = false;
    public GameObject TarotMenus; // Asigna aquí el script de movimiento del personaje
    public CharacterMovement characterMovement; // Asigna aquí el script de movimiento del personaje
    private void Start()
    {
        teclas.SetActive(false);
    }
    private void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TarotMenus.SetActive(true);
                characterMovement.paused = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canInteract = true; // Permitir interacción al entrar en el trigger
            teclas.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canInteract = false; // Desactivar interacción al salir del trigger
            teclas.SetActive(false);
        }
    }
}
