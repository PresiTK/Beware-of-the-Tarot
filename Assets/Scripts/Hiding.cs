using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    public GameObject player;
    public bool hide = false;
    public EnemyDetection shown;
    public bool notseen=false;

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
            hide = true;
            shown.vision = false;
            Debug.Log("No te veo");
            notseen = !notseen;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hide = false;
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
