using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public bool vision = false;
    public int speed = 20;
    public GameObject player;
    public GameObject face_light;
    public CircleCollider2D trigger;
    public float detectionRange = 5f;
    public Animator animator;


    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<CircleCollider2D>();
        trigger.radius = detectionRange;
        face_light.SetActive(false);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            player = collision.gameObject;
            vision = true;
            face_light.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            vision = false;
            animator.SetTrigger("Walk");
            face_light.SetActive(false);
        }
    }
    public void FollowPlayer(Transform enemytransform)
    {
        enemytransform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        CheckRotation(enemytransform.position, player.transform.position);
    }

    void CheckRotation(Vector2 origin, Vector2 destination)
    {
        if (origin.x > destination.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
}
