using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public enum Direction { NONE_DOWN,NONE_UP,NONE_LEFT,NONE_RIGHT, UP, DOWN, LEFT, RIGHT , DIAGONAL_UP_RIGHT, DIAGONAL_UP_LEFT, DIAGONAL_DOWN_RIGHT, DIAGONAL_DOWN_LEFT };
public class CharacterMovement : MonoBehaviour
{
    
    public float speedX = 1;
    public float speedY = 1;
    public bool light_flash=false;
    public float runingMultyply = 1.5f;
    private bool isRunning= false;
    public GameObject tarotSprite;
    public GameObject newTarotSprite;
    private float Stamina=2f;

    public Rigidbody2D rb2d;
    public SpriteRenderer sprRender;

    public GameObject flashlight;
    public Pause pause;
    public Direction direction = Direction.NONE_DOWN;
    private Direction lastDirection=Direction.NONE_DOWN;

    public bool isHiding = false;
    public bool isSearching = false;
    private PlayerAudio playerAudio;

    public bool pressingHide = false;
    private Animator animator;
    private Vector2 vector2;
    public bool WinIsActive = false;

    void Start()
    {
        tarotSprite.SetActive(true);
        newTarotSprite.SetActive(false);
        light_flash = false;
        rb2d = GetComponent<Rigidbody2D>();
        sprRender = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        flashlight.SetActive(light_flash);
        playerAudio = GetComponent<PlayerAudio>();
        playerAudio.flashlifht.Stop();
        playerAudio.LightNo();
    }
    private void FixedUpdate()
    {
        Moving();
    }
    void Update()
    {
        if (WinIsActive)
        {
            tarotSprite.SetActive(false);
            newTarotSprite.SetActive(true);
        }
        UpdateDirection();
        PlayAnimation();

    
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerAudio.FlashlightOn();
            light_flash = !light_flash;
            flashlight.SetActive(light_flash);
            if (light_flash)
            {
                playerAudio.LightActive();
            }
            else
            {
                playerAudio.LightNo();
            }
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            isHiding = !isHiding ;
        }
        //if (Input.GetKeyDown(KeyCode.Escape) && pause.pauseMenu != null)
        //{
        //    pause.Resume();
        //}
        if (Stamina < 0f)
        {
            Stamina = 0f;
            isRunning = false;
        }
        else if (Input.GetKey(KeyCode.LeftShift) &&  Stamina>0f)
        {
            
            isRunning = true;
            Stamina -= Time.deltaTime;
        }
        else if(direction == Direction.NONE_DOWN|| direction == Direction.NONE_UP || direction == Direction.NONE_RIGHT|| direction == Direction.NONE_LEFT)
        {
            isRunning = false;

            // Regenera stamina si el jugador no corre
            if (Stamina < 2f)
            {
                Stamina += Time.deltaTime;
                Stamina = Mathf.Min(Stamina, 1.5f); // Límite superior
            }
        }
    }
    //private void OnEnable()
    //{
    //    InputController.OnInteract += TogglePressingHide;
    //}
    //private void OnDisable()
    //{
    //    InputController.OnInteract -= TogglePressingHide;
    //}
    //public void TogglePressingHide()
    //{
    //    Renderer.enabled = pressingHide;

    //}



    private void Moving()
    {
        if (rb2d == null) { return; } 
        if (isHiding) { return; }

        float hInput = 0;
        float vInput = 0;

        switch (direction)
        {
            case Direction.UP:
                vInput = 1;
                break;

            case Direction.DOWN:
                vInput = -1;
                break;
            case Direction.LEFT:
                hInput = -1;
                break;
            case Direction.RIGHT:
                hInput = 1;
                break;
            case Direction.DIAGONAL_UP_RIGHT:
                vInput = 1;
                hInput = 1;
                break;
            case Direction.DIAGONAL_UP_LEFT:
                vInput = 1;
                hInput = -1;
                break;
            case Direction.DIAGONAL_DOWN_RIGHT:
                vInput = -1;
                hInput = 1;
                break;
            case Direction.DIAGONAL_DOWN_LEFT:
                vInput = -1;
                hInput = -1;
                break;
            default:
                break;
        }

        Vector2 movement = new Vector2(hInput, vInput).normalized;
        vector2 = movement;
        if (isRunning)
        {
            rb2d.velocity = new Vector2(movement.x * speedX*runingMultyply * Time.fixedDeltaTime, movement.y * speedY*runingMultyply * Time.fixedDeltaTime);

        }
        else
        {
            rb2d.velocity = new Vector2(movement.x * speedX * Time.fixedDeltaTime, movement.y * speedY * Time.fixedDeltaTime);
        }
    }
    private void UpdateDirection()
    {
        direction = Direction.NONE_DOWN;
        if(isHiding) { return; }

        int horizontal = 0;
        int vertical = 0;

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)) { vertical += 1; horizontal += 1; ;  }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)) { vertical -= 1; horizontal -= 1; }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)) { vertical += 1; horizontal -= 1;}
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)) { vertical -= 1; horizontal += 1;}
        else
        {
            if (Input.GetKey(KeyCode.DownArrow)) { vertical -= 1; }
            if (Input.GetKey(KeyCode.UpArrow)) { vertical += 1; }
            if (Input.GetKey(KeyCode.LeftArrow)) { horizontal -= 1;}
            if (Input.GetKey(KeyCode.RightArrow)) { horizontal += 1;}

        }
        if (vertical == 0 && horizontal == 0)
        {
            if (lastDirection == Direction.DOWN)
            {
                direction = Direction.NONE_DOWN;
            }
            else if (lastDirection == Direction.UP) {
                direction = Direction.NONE_UP;
            }
            else if (lastDirection == Direction.RIGHT||lastDirection==Direction.DIAGONAL_UP_RIGHT||lastDirection==Direction.DIAGONAL_DOWN_RIGHT)
            {
                direction = Direction.NONE_RIGHT;
            }
            else if (lastDirection == Direction.LEFT||lastDirection==Direction.DIAGONAL_DOWN_LEFT||lastDirection==Direction.DIAGONAL_UP_LEFT)
            {
                direction = Direction.NONE_LEFT;
            }

        }
        if (vertical == horizontal)
        {
            if (vertical < 0)
            {
                direction = Direction.DIAGONAL_DOWN_LEFT;
            }
            if (horizontal > 0)
            {
                direction = Direction.DIAGONAL_UP_RIGHT;
            }
        }
        else if (vertical * (-1) == horizontal)
        {
            if (vertical < horizontal)
            {
                direction = Direction.DIAGONAL_DOWN_RIGHT;

            }
            if (vertical > horizontal)
            {
                direction = Direction.DIAGONAL_UP_LEFT;

            }
        }
        else
        {
            if (vertical > 0)
            {
                direction = Direction.UP;
            }
            else if (vertical < 0)
            {
                direction = Direction.DOWN;
            }

            if (horizontal < 0)
            {
                direction = Direction.LEFT;

            }
            else if (horizontal > 0)
            {
                direction = Direction.RIGHT;
            }
        }
        if (isSearching)
        {
            direction = Direction.NONE_DOWN;
        }
        if (isHiding)
        {
            direction = Direction.NONE_DOWN;
        }
        if(direction != Direction.NONE_DOWN && direction != Direction.NONE_UP && direction != Direction.NONE_LEFT && direction != Direction.NONE_RIGHT)
        {
            if (!playerAudio.steps.isPlaying)
            {
                playerAudio.StepsOn();
            }
        }
        else
        {
            playerAudio.StepsOff();
        }

    }


    private void PlayAnimation()
    {
        if (isRunning)
        {

            switch (direction)
            {

                case Direction.NONE_DOWN:
                    animator.SetTrigger("Static");
                    break;
                case Direction.NONE_UP:
                    animator.SetTrigger("Static_Up");
                    break;
                case Direction.NONE_LEFT:
                    animator.SetTrigger("Static_Left");
                    break;
                case Direction.NONE_RIGHT:
                    animator.SetTrigger("Static_Right");
                    break;
                case Direction.UP:
                    lastDirection = Direction.UP;
                    animator.SetTrigger("RuningUp");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case Direction.DOWN:
                    lastDirection = Direction.DOWN;
                    animator.SetTrigger("RuningDown");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
                case Direction.DIAGONAL_UP_LEFT:
                case Direction.DIAGONAL_DOWN_LEFT:
                case Direction.LEFT:
                    lastDirection = Direction.LEFT;
                    animator.SetTrigger("RuningLeft");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 90);
                    break;
                case Direction.DIAGONAL_DOWN_RIGHT:
                case Direction.DIAGONAL_UP_RIGHT:
                case Direction.RIGHT:
                    lastDirection = Direction.RIGHT;
                    animator.SetTrigger("RuningRight");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, -90);
                    break;
                default:
                    animator.SetTrigger("Static");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
            }
        }
        else
        {
            switch (direction)
            {

                case Direction.NONE_DOWN:
                    animator.SetTrigger("Static");
                    break;
                case Direction.NONE_UP:
                    animator.SetTrigger("Static_Up");
                    break;
                case Direction.NONE_LEFT:
                    animator.SetTrigger("Static_Left");
                    break;
                case Direction.NONE_RIGHT:
                    animator.SetTrigger("Static_Right");
                    break;
                case Direction.UP:
                    lastDirection = Direction.UP;
                    animator.SetTrigger("Up");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case Direction.DOWN:
                    lastDirection = Direction.DOWN;
                    animator.SetTrigger("Down");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
                case Direction.DIAGONAL_UP_LEFT:
                case Direction.DIAGONAL_DOWN_LEFT:
                case Direction.LEFT:
                    lastDirection = Direction.LEFT;
                    animator.SetTrigger("Left");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 90);
                    break;
                case Direction.DIAGONAL_DOWN_RIGHT:
                case Direction.DIAGONAL_UP_RIGHT:
                case Direction.RIGHT:
                    lastDirection = Direction.RIGHT;
                    animator.SetTrigger("Right");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, -90);
                    break;
                default:
                    animator.SetTrigger("Static");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
            }
        }
    }


}
