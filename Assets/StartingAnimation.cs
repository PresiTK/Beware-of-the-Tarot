using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class StartingAnimation : MonoBehaviour
{
    public GameObject textbox;
    private bool animationStarted = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!animationStarted)
            {
                animationStarted = true;
                collision.GetComponent<CharacterMovement>().animationIsDone = false;
                textbox.SetActive(true);
            }

        }
    }
}
