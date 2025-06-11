using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

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

    }

    private void Update()
    {
        if(isPlayerInRange)
        {
            FollowCharacter();
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

        Vector2 offsetedpos = transform.position;


        if (Vector2.Distance(offsetedpos, target) < distanciaMinima)
        {
            StartCoroutine(NextOrderedPath());
            if(yendoAdelante)
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
    }
    private void FollowCharacter()
    {
        velocidadMovimiento = 9f;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocidadMovimiento * Time.deltaTime);
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
        // Teletransporte hacia atrás
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
            isPlayerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

}
