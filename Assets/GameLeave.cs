using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLeave : MonoBehaviour
{

    private Renderer Tecla;
    public Canvas text;
    public CharacterMovement chara;

    private void Start()
    {
        Tecla = GetComponent<Renderer>();
        Tecla.enabled = false;
        text.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!chara.WinIsActive)
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


