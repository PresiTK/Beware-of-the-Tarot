using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    private GameObject player;
    private Animator animator;
    public CharacterHide characterHide;
    [SerializeField] private GameObject image;
    private bool hidedwasPressed = false;
    private AudioSource hided_sound;

    private float timeEndAnim = 0;


    private bool hide = false;
    private void Start()
    {
        hided_sound = GetComponent<AudioSource>();
        hided_sound.Stop();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {

        if(timeEndAnim > 0)
        {
            timeEndAnim -= Time.deltaTime;
            if (timeEndAnim <= 0)
            {
                Debug.Log("End Animation");
                animator.SetBool("Hide", false);
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && hide)
        {
            characterHide.Hide();
            hidedwasPressed = true;
            hided_sound.Play();
            animator.SetBool("Hide", true);
            timeEndAnim = 0.5f;
        }
        else if (Input.GetKeyDown(KeyCode.E) && !hide&& hidedwasPressed)
        {
            characterHide.UnHide();
            hidedwasPressed = false;
            hided_sound.Play();
            animator.SetBool("Hide", true);
            timeEndAnim = 0.5f;
        }
        else
        {
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            player = collision.gameObject;
            image.SetActive(true);
            hide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            player = null;
            hide = false;
            image.SetActive(false);
        }
    }

    public void OnAnimationEnd()
    {
        animator.SetBool("Hide", false);
    }
}
