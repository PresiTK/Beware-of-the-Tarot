using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeclaFable : MonoBehaviour
{
    private Renderer Tecla;
    public Canvas text;
    public TutorialNextScene tutorialNextScene;

    private void Start()
    {
        Tecla = GetComponent<Renderer>();
        Tecla.enabled = false;
        text.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!tutorialNextScene.CanContinue)
        {
            Tecla.enabled = true;
            text.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Tecla.enabled = false;
        text.enabled = false;

    }
}
