using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeclaFable : MonoBehaviour
{
    private Renderer Tecla;
    public Canvas text;

    private void Start()
    {
        Tecla = GetComponent<Renderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Tecla.enabled = true;
        text.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Tecla.enabled = false;
        text.enabled = false;

    }
}
