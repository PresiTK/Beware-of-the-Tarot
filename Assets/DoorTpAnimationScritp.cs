using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DoorTpAnimationScritp : MonoBehaviour
{
    private bool isPaused = false;
    private bool flashlight = false;    
    private AudioSource audioSource;
    public AudioClip[] audioClips;
    private Animator animator;
    public Light2D globalLight;
    public GameObject playerLight;
    public CharacterMovement characterMovement;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        audioSource.clip = audioClips[0]; // Asignar el primer clip de audio al AudioSource
        animator.updateMode = AnimatorUpdateMode.UnscaledTime; // Permitir animación con Time.timeScale = 0
    }

    private void SoundCrack()
    {
        audioSource.clip = audioClips[0]; // Asignar el clip de sonido de la puerta al abrirse
        audioSource.Play(); // Reproduce el sonido de la puerta al abrirse
        Debug.Log("Sonido de puerta al abrirse");
    }

    public void Pausedespause()
    {

        if (isPaused)
        {
            
            Time.timeScale = 1f; // Reanudar el juego
            isPaused = false;
            characterMovement.paused = isPaused; // Reanudar el movimiento del personaje

            animator.SetBool("show", isPaused);
            audioSource.clip = audioClips[1]; // Asignar el clip de sonido de la puerta al cerrarse
            audioSource.Play(); // Reproduce el sonido de la puerta al cerrarse
            globalLight.intensity = 0.05f; // Restaurar la intensidad de la luz global
            if(flashlight)
            {
                flashlight = false; // Desactivar la linterna al cerrar la puerta
                playerLight.SetActive(true); // Desactivar la luz del jugador al cerrar la puerta
            }
        }
        else
        {
            if (playerLight.activeSelf)
            {
                playerLight.SetActive(false); // Desactivar al jugador al abrir la puerta
                flashlight = true; // Activar la linterna al abrir la puerta
            }
            globalLight.intensity = 0.4f; // Aumentar la intensidad de la luz global al abrir la puerta
            Time.timeScale = 0f; // Pausar el juego
            isPaused = true;
            characterMovement.paused = isPaused; // Reanudar el movimiento del personaje

            animator.SetBool("show", isPaused);

        }
    }
}
