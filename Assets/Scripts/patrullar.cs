using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrullar : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distanciMinima;
    private int numeroAleatorio;

    private void Start()
    {
        numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
    }

    public void FollowPath()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[numeroAleatorio].position, velocidadMovimiento * Time.deltaTime);
        if (Vector2.Distance(transform.position, puntosMovimiento[numeroAleatorio].position) < distanciMinima)
        {
            numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
        }
    }
}

