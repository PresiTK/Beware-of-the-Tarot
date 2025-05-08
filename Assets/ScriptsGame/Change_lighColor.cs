using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Change_lighColor : MonoBehaviour
{
    public GameObject player;
    public Light2D Light;
    private bool range=false;
    private float speed =5;

    private void Update()
    {
        if (range)
        {
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
