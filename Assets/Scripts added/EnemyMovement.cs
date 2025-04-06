using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public EnemyDetection detection;
    public GameOverScreen gameOverScreen;
    public CharacterMovement hide;
    public patrullar patrol;
    private bool enter = false;
    public GameObject door;
    private Vector2 teleportPosition = Vector2.zero;
    private Animator animator;


    void Start()
    {
        if(player != null)
        {
            hide=player.GetComponent<CharacterMovement>();
        }
        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        MovementTowardsPlayer();
    }

    void MovementTowardsPlayer()
    {
        if (detection.vision == false)
        {

        }
        if (detection.vision && !hide.isHiding)
        {
            animator.SetTrigger("Run");
            detection.FollowPlayer(transform);
        }
        else
        {
            patrol.FollowPath();
        }
        if(enter)
        {
            Teleport();
            patrol.FollowPath();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")&& !hide.isHiding)
        {
            Destroy(collision.gameObject);
            gameOverScreen.GameOverMenu();

        }
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
