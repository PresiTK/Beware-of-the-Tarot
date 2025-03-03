using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public bool vision = false;
    public int speed = 20;
    public GameObject player;
    public CircleCollider2D trigger;
    public float detectionRange = 5f;
    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<CircleCollider2D>();
        trigger.radius = detectionRange;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            player = collision.gameObject;
            vision = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            vision = false;
        }
    }
    public void FollowPlayer(Transform enemytransform)
    {
        enemytransform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
