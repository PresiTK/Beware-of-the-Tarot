using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public int speed = 3;
    public EnemyDetection detection;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        MovementTowardsPlayer();
    }

    void MovementTowardsPlayer()
    {
        if (detection.vision == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
