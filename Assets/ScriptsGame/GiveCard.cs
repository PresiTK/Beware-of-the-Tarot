using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveCard : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject teclas;
    private bool canInteract = false;
    public GameObject Card1;
    public GameObject Card2;
    private AudioSource audioSource;
    public bool Given = false; // Variable para verificar si la carta ya fue entregada
    public CharacterMovement player;
    public Animator hoppyAnimator;
    public GestotAnim textBox;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Card1.SetActive(false);
        Card2.SetActive(true);
        teclas.SetActive(false);
    }
    private void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(!Given)
                {
                    Card1.SetActive(true); // Activar la carta 1
                    Card2.SetActive(false); // Desactivar la carta 2
                    audioSource.Play(); // Reproducir el sonido de la carta
                    Given=true; // Marcar que la carta ha sido entregada
                    player.animationIsDone = false;
                    hoppyAnimator.SetTrigger("Return"); // Activar la animación de entrega de carta
                    textBox.ShowTextBox(); // Activar el cuadro de texto
                }
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
