using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    private bool enter = false;
    public GameObject door;
    public CharacterMovement ubi;
    public CameraTp teleport;
    private Vector2 teleportPosition = Vector2.zero;
    private void Update()
    {
        if (enter && Input.GetKeyDown(KeyCode.E))
        {
            Teleport();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Door"))
        {
            door = collision.gameObject;
            Enlace link = collision.gameObject.GetComponent<Enlace>();
            if (link != null)
            {
                teleportPosition = link.GetTeleportPosition();
                enter = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Door"))
        {
            door = null;
            enter = false;
        }
    }

    private void Teleport()
    {
        if (door != null) 
        {
            transform.position = teleportPosition;
            door = null;
            enter = false;
        }
    }
}
