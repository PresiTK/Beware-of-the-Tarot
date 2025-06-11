using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcanaMenor : MonoBehaviour
{
    public Transform destinoA;
    public Transform destinoB;
    public float velocidad = 2.0f;

    private Transform objetivoActual;
    private bool haciaB = true;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        objetivoActual = destinoB;

        // Obtiene el SpriteRenderer del objeto
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogWarning("No se encontró un SpriteRenderer en este GameObject.");
        }
    }

    void Update()
    {
        // Mueve el objeto hacia el objetivo actual
        transform.position = Vector3.MoveTowards(transform.position, objetivoActual.position, velocidad * Time.deltaTime);

        // Cambia el objetivo cuando llega
        if (Vector3.Distance(transform.position, objetivoActual.position) < 0.01f)
        {
            haciaB = !haciaB;
            objetivoActual = haciaB ? destinoB : destinoA;
        }

        // Ajusta flipX según la dirección en X

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
}
