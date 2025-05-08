using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Change_lighColor : MonoBehaviour
{
    public GameObject player;
    public GameObject arribed;
    public Light2D Light;
    private bool range=false;
    private float speed =5;
    private bool goAway = false;


    private void Update()
    {
        if (range)
        {
            goAway = true;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            if (player.transform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);

            }
        }
        if(goAway&&!range)
        {
            speed = 3;
            transform.position = Vector2.MoveTowards(transform.position, arribed.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if(transform.position.x == arribed.transform.position.x)
            {
                transform.position = new Vector2(transform.position.x, 1000000f);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Light.color = Color.red;
        range = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Light.color = Color.white;
        range = false;
    }

}
