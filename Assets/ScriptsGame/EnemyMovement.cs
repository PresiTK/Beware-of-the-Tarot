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
    private EnemyAudio audio;
    private bool patrolling = true;
    private float timer = 1f;
    private bool canKill = false;
    public Animator Scream;

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
        timer -= Time.deltaTime;

        audio = GetComponent<EnemyAudio>();
        audio.PatrolOff();
        audio.ChaseOff();
        audio.ScreamOff();
    }

    // Update is called once per frame
    void Update()
    {
        MovementTowardsPlayer();
    }

    void MovementTowardsPlayer()
    {

        if (detection.vision && !hide.isHiding)
        {
            if (patrolling)
            {
                audio.PatrolOff();
                audio.ChaseOn();
                animator.SetTrigger("Detected");

            }
            timer -= Time.deltaTime;
            patrolling = false;

            if (timer <= 0f)
            {
                canKill = true;
                animator.SetTrigger("Run");
                detection.FollowPlayer(transform);
            }

        }
        else
        {
            if (!patrolling)
            {
                audio.ChaseOff();
                audio.PatrolOn();
            }
            timer = 1f;
            canKill = false;
            patrolling = true;
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
            if(canKill)
            {
                audio.ChaseOff();
                audio.Scream();
                Destroy(collision.gameObject);
                Scream.SetTrigger("ScreamColgado");
            }
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
