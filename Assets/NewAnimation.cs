using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAnimation : MonoBehaviour
{

    public TextBoxControl textBoxControl;
    private bool Once = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&Once)
        {
            textBoxControl.ShowTextBox();
            Once = false;
        }
    }
}
