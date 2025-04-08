using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    private List<Transform> puntosEnTrigger = new List<Transform>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PuntoMovimiento"))
        {
            puntosEnTrigger.Add(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PuntoMovimiento"))
        {
            puntosEnTrigger.Remove(other.transform);
        }
    }

    public List<Transform> ObtenerPuntosValidos(Transform[] todosLosPuntos)
    {
        List<Transform> puntosValidos = new List<Transform>();

        foreach (Transform punto in todosLosPuntos)
        {
            if (puntosEnTrigger.Contains(punto))
            {
                puntosValidos.Add(punto);
            }
        }

        return puntosValidos;
    }
}
