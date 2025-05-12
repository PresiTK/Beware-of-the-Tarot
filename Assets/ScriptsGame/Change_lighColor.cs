using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Change_lighColor : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    public GameObject player;
    public GameObject arribed;
    public Light2D Light;
    private bool range=false;
    private float speed =5;
    private bool goAway = false;
    private Vector2 initialpos = Vector2.zero;
    [SerializeField] GameObject restart;
    public CameraMovement tpcam;
    private void Start()
    {
        initialpos = transform.position;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        anim.SetBool("Range", range);

        if (range)
        {

            goAway = true;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            if (player.transform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
                spriteRenderer.flipY = true;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                spriteRenderer.flipY = false;

            }
        }
        else if(goAway&&!range)
        {
            speed = 3;
            transform.position = Vector2.MoveTowards(transform.position, arribed.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            spriteRenderer.flipY = false;  
            if (transform.position.x == arribed.transform.position.x)
            {
                transform.position = new Vector2(transform.position.x, 1000000f);

            }
        }
        if (transform.position == player.transform.position){
            transform.position=initialpos;
            player.transform.position = restart.transform.position;
            goAway = false;
            range = false;
            tpcam.RecallCam();
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
