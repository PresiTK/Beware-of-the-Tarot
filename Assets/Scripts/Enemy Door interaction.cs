using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Windows;

public class EnemyDoorInteraction : MonoBehaviour
{
    public float speedX = 1;
    public float speedY = 1;
    private bool wait = false;

    public GameObject door;
    private Vector2 teleportPosition = Vector2.zero;
    Rigidbody2D rb2d;
    private void Start()
    {

    }
    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        wait = true;
        if (wait)
        {
            if (collision.gameObject.tag.Equals("Door"))
            {
                door = collision.gameObject;
                Enlace link = collision.gameObject.GetComponent<Enlace>();
                if (link != null)
                {
                    teleportPosition = link.GetTeleportPosition();
                }
            }
            Teleport();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Door"))
        {
            door = null;
            wait = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Door"))
        { 

        }
    }
        private void Teleport()
    {
        if (door != null)
        {
            transform.position = teleportPosition;
            door = null;
        }
    }
}
