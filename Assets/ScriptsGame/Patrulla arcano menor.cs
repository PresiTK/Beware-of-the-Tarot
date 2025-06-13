using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Patrullaarcanomenor : MonoBehaviour
{
    [Header("Patrullaje")]
    [SerializeField] private float velocidadMovimiento = 2f;
    [SerializeField] private float distanciaMinima = 0.1f;
    [SerializeField] private List<Transform> puntosDeRuta; // Define estos en el Inspector

    [Header("Referencias")]
    public GameObject player;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;
    private bool isPlayerInRange = false;
    private Vector2 target;
    private int indiceActual = 0;
    private bool yendoAdelante = true;
    private bool iswaiting = false;
    public GameOverScreen gameOverScreen;
    public Light2D light2D;
    private float timer = 1f; // Tiempo para seguir al jugador

    public AudioSource patrol;
    public AudioSource follow;
    public AudioSource attack;
    private Animator anim;
    public Animator Scream;

    private void Start()
    {
        follow.Stop();
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        patrol.Play();
        anim = GetComponent<Animator>();
        if (puntosDeRuta == null || puntosDeRuta.Count == 0)
        {
            Debug.LogWarning("No se asignaron puntos de patrullaje.");
            enabled = false;
            return;
        }
        target = puntosDeRuta[indiceActual].position + new Vector3(0, 2f, 0);
        sprite.flipY = true;
        transform.rotation = Quaternion.Euler(0, 0, 180);
        isPlayerInRange = false;
        attack.Stop();
    }

    private void Update()
    {
        anim.SetBool("Range", isPlayerInRange);

        if (isPlayerInRange)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                FollowCharacter();

            }

        }
        else
        {
            FollowPath();

        }
    }

    private void FollowPath()
    {
        if (iswaiting) return;
        velocidadMovimiento = 5f; // Velocidad de patrullaje
        transform.position = Vector2.MoveTowards(transform.position, target, velocidadMovimiento * Time.deltaTime);

        if (yendoAdelante)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            sprite.flipY = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            sprite.flipY = false;
        }
        Vector2 offsetedpos = transform.position;


        if (Vector2.Distance(offsetedpos, target) < distanciaMinima)
        {
            StartCoroutine(NextOrderedPath());

        }
    }
    private void FollowCharacter()
    {
        velocidadMovimiento = 9f;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocidadMovimiento * Time.deltaTime);
        if(transform.position == player.transform.position)
        {
            attack.Play();
            follow.Stop();
            Destroy(player.gameObject);
            Scream.SetTrigger("MinorScream");
        }
        else
        {
            attack.Stop();
        }
        if (transform.position.x < player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            sprite.flipY = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            sprite.flipY = false;
        }
    }

    IEnumerator NextOrderedPath()
    {
        iswaiting = true;

        yield return new WaitForSeconds(1f);

        // Teletransporte hacia adelante
        if (yendoAdelante)
        {
            sprite.flipX = true; // mirando a la derecha
            if (indiceActual == 1)
            {
                indiceActual = 2;
                transform.position = puntosDeRuta[indiceActual].position + new Vector3(1f, 2f, 0);
            }
            else if (indiceActual == 3)
            {
                indiceActual = 4;
                transform.position = puntosDeRuta[indiceActual].position + new Vector3(1f, 2f, 0);
            }
            else
            {
                indiceActual++;
                if (indiceActual >= puntosDeRuta.Count)
                {
                    indiceActual = puntosDeRuta.Count - 2;
                    yendoAdelante = false;
                }
            }
        }
        // Teletransporte hacia atr�s
        else
        {
            sprite.flipX = false; // mirando a la derecha
            if (indiceActual == 4)
            {
                indiceActual = 3;
                transform.position = puntosDeRuta[indiceActual].position + new Vector3(1f, 2f, 0);
            }
            else if (indiceActual == 2)
            {
                indiceActual = 1;
                transform.position = puntosDeRuta[indiceActual].position + new Vector3(1f, 2f, 0);
            }
            else
            {
                indiceActual--;
                if (indiceActual < 0)
                {
                    indiceActual = 1;
                    yendoAdelante = true;
                }
            }
        }

        // Asigna el nuevo objetivo
        target = puntosDeRuta[indiceActual].position + new Vector3(0, 2f, 0);

        iswaiting = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            light2D.color = Color.red;
            isPlayerInRange = true;
            patrol.Stop();
            follow.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            light2D.color = Color.white;

            isPlayerInRange = false;
            follow.Stop();
            patrol.Play();
            timer = 1f; // Reinicia el temporizador al salir del rango del jugador
        }
    }

}
