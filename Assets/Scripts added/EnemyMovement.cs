using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public int speed = 20;
    public EnemyDetection detection;
    public GameOverScreen gameOverScreen;
    public CharacterMovement hide;
    void Start()
    {
        if(player != null)
        {
            hide=player.GetComponent<CharacterMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovementTowardsPlayer();
    }

    void MovementTowardsPlayer()
    {
        if(player!= null)
        {
            if (detection.vision && !hide.isHiding)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(collision.gameObject);
            gameOverScreen.GameOverMenu();

        }
    }
}
