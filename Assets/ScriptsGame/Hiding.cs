using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private GameObject image;

    private bool hide = false;

    private void Update()
    {
        if (hide && Input.GetKeyDown(KeyCode.E)) 
        { 
            TeleportPlayer();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            image.SetActive(true);
            hide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hide = false;
        image.SetActive(false);
    }

    public Vector2 TeleportPlayer()
    {
        if (player != null) 
        {
            player.transform.position = transform.position; 
        }
        return player.transform.position;
    }
}
