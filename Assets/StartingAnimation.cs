using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class StartingAnimation : MonoBehaviour
{
    public GameObject textbox;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<CharacterMovement>().animationIsDone = false;
            textbox.SetActive(true);
        }
    }
}
