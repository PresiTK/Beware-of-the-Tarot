using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullar : MonoBehaviour
{
    [SerializeField] private float velocidaMovimiento;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distanciaMinima;
    public bool punto;
    private int numeroAleatrio;
    float timer = 0.5f;
    private void Start()
    {
        numeroAleatrio = Random.Range(0, puntosMovimiento.Length);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[numeroAleatrio].position, velocidaMovimiento * Time.deltaTime);
        if (Vector2.Distance(transform.position, puntosMovimiento[numeroAleatrio].position) < distanciaMinima)
        {
            numeroAleatrio = Random.Range(0, puntosMovimiento.Length);
        }
        if (punto)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                return;
            }
            timer = 0.5f;
        }
    }
}
