using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.U2D;

public class ArcanaMenor : MonoBehaviour
{
    public Transform destinoA;
    public Transform destinoB;
    public float velocidad = 2.0f;
    public GameObject player;
    public GameOverScreen gameOverScreen;
    public Light2D Light;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public Animator Screamer;
    public AudioSource scream;
    private Transform objetivoActual;
    private bool haciaB = true;
    private SpriteRenderer spriteRenderer;
    private bool isPlayerInRange = false;
    private float timer = 4f; // Tiempo para seguir al jugador
    void Start()
    {
        objetivoActual = destinoB;

        // Obtiene el SpriteRenderer del objeto
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogWarning("No se encontr� un SpriteRenderer en este GameObject.");
        }
        audioSource.clip = audioClips[0]; // Asigna el clip de patrullaje al inicio 
        audioSource.Play();

    }

    void Update()
    {
        if (isPlayerInRange)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                FollowCharacter();
            }
            if(player.transform.position.x > transform.position.x)
            {
                spriteRenderer.flipY = true; // mirando a la derecha
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else
            {
                spriteRenderer.flipY = false; // mirando a la izquierda
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            Patrol();
        }
    }
    private void Patrol()
    {
        velocidad = 2.0f; // Velocidad de patrullaje
        transform.position = Vector3.MoveTowards(transform.position, objetivoActual.position, velocidad * Time.deltaTime);

        // Cambia el objetivo cuando llega
        if (Vector3.Distance(transform.position, objetivoActual.position) < 0.01f)
        {
            haciaB = !haciaB;
            objetivoActual = haciaB ? destinoB : destinoA;
        }

        // Ajusta flipX seg�n la direcci�n en X

        if (objetivoActual.position.x > transform.position.x)
        {
            spriteRenderer.flipY = true; // mirando a la derecha
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            spriteRenderer.flipY = false; // mirando a la izquierda
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
    }

    private void FollowCharacter()
    {
        velocidad = 12f;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocidad * Time.deltaTime);
        if (transform.position == player.transform.position)
        {
            Destroy(player.gameObject);
            gameOverScreen.GameOverMenu();
            Screamer.SetTrigger("MinorScream");
            scream.clip = audioClips[2]; // Cambia el clip de audio a grito
            scream.Play(); // Reproduce el grito
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.clip = audioClips[1]; // Cambia el clip de audio a persecuci�n
            audioSource.Play(); // Reproduce el clip de persecuci�n
            isPlayerInRange = true;
            Light.color = Color.red; // Cambia el color de la luz al entrar en rango
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.clip = audioClips[0]; // Cambia el clip de audio a patrullaje
            isPlayerInRange = false;
            Light.color = Color.white; // Restaura el color de la luz al salir del rango
            timer= 4f; // Reinicia el temporizador al salir del rango del jugador
        }
    }
}

