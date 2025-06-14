using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAnimationEnd : MonoBehaviour
{
    public TextBoxControl textBoxControl;
    public CharacterMovement characterMovement; 
    private bool Once = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Once&&characterMovement.WinIsActive)
        {
            textBoxControl.ShowTextBox();
            Once = false;
        }
    }
}
