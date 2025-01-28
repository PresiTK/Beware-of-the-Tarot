using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    private bool enter = false;
    private void Update()
    {
        if (enter && Input.GetKeyDown(KeyCode.E))
        {
            Teleport();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enter = true;
    }

    private void Teleport()
    {
        transform.position = new Vector2(12f, -1.41f);
    }
}
