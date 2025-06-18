using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Change_lighColor : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    public  Vector3 firstPosition;
    public GameObject player;
    public GameObject arribed;
    public GameObject restart;
    public Light2D Light;
    private AudioSource audioSource;
    private bool range=false;
    private float speed =5;
    private bool goAway = false;
    public CameraMovement camtp;
    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();  
        firstPosition = transform.position;
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
            player.transform.position = restart.transform.position;
            transform.position=firstPosition;
            camtp.TeleportToRoom(new Vector2(player.transform.position.x, player.transform.position.y+2));
            goAway = false;
            range = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Light.color = Color.red;
        range = true;
        audioSource.Play();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Light.color = Color.white;
        range = false;
        audioSource.Stop();
    }

}
