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
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb2d.velocity = new Vector2(100 * speedX * Time.fixedDeltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        wait = !wait;
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
