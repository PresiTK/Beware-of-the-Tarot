using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public enum Direction { NONE, UP, DOWN, LEFT, RIGHT , DIAGONAL_UP_RIGHT, DIAGONAL_UP_LEFT, DIAGONAL_DOWN_RIGHT, DIAGONAL_DOWN_LEFT };
public class CharacterMovement : MonoBehaviour
{
    public float speedX = 1;
    public float speedY = 1;
    public bool light_flash=false;
    public float runingMultyply = 2f;
    private bool isRunning= false;

    Rigidbody2D rb2d;
    public SpriteRenderer sprRender;
    public Renderer Renderer;

    public GameObject flashlight;
    public Pause pause;
    public Direction direction = Direction.NONE;

    public float currShootTime = 0;
    public float shootCadenceTime = 2.0f;

    public bool isHiding = false;
    public bool isSearching = false;

    public bool pressingHide = false;
    private Animator animator;
    private Vector2 vector2;
    // Start is called before the first frame update

    void Start()
    {
        light_flash = false;
        rb2d = GetComponent<Rigidbody2D>();
        sprRender = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        flashlight.SetActive(light_flash);
        Renderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirection();
        PlayAnimation();
        Shoot();

    
        if (Input.GetKeyDown(KeyCode.F))
        {
            light_flash = !light_flash;
            flashlight.SetActive(light_flash);
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            isHiding = !isHiding ;
        }
        //if (Input.GetKeyDown(KeyCode.Escape) && pause.pauseMenu != null)
        //{
        //    pause.Resume();
        //}

        isRunning = Input.GetKey(KeyCode.LeftShift);
  

    }
    private void OnEnable()
    {
        InputController.OnInteract += TogglePressingHide;
    }
    private void OnDisable()
    {
        InputController.OnInteract -= TogglePressingHide;
    }
    public void TogglePressingHide()
    {
        Renderer.enabled = pressingHide;

    }

    private void FixedUpdate()
    {
        moving();

    }

    private void moving()
    {
        //Siempre comprobar si los componentes existen antes de usarlos
        if (rb2d == null) { return; } //Si no existe me piro y no hago nada, me ahorro c�lculos

        //Separamos l�gica de f�sica
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
        //Separamos l�gica de f�sica
        direction = Direction.NONE;
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
            direction =Direction.NONE;
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
        if (isSearching || isHiding)
        {
            direction = Direction.NONE;
        }
    }

    private void Shoot(){   
        if (Input.GetKeyDown(KeyCode.Space)){
            currShootTime = 0;
            Debug.Log("START SHOOTING");
        }else if (Input.GetKey(KeyCode.Space)){
            currShootTime += Time.deltaTime;
            if (currShootTime > shootCadenceTime)
            {
                currShootTime = 0;
                Debug.Log("CONTINUOUS SHOOTING");
            }
        }else{
            currShootTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Hiding")&& pressingHide)
        {
            pressingHide = false;
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("Te mueres");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Hiding"))
        {
            HideInPlace(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Hiding"))
        {
            HideInPlace(pressingHide);
        }
        if (collision.gameObject.tag.Equals("win"))
        {
            HideInPlace(pressingHide);
        }

    }

    private void HideInPlace(bool hide)
    {
        isHiding = hide;
        if (sprRender != null)
        {
            Color col = sprRender.color;
            col.a = isHiding ? 0f : 1f; 
            sprRender.color = col;
        }
    }
    private void PlayAnimation()
    {
        if (isRunning)
        {
            switch (direction)
            {

                case Direction.NONE:
                    animator.SetTrigger("Static");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
                case Direction.UP:
                    animator.SetTrigger("RuningUp");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case Direction.DOWN:
                    animator.SetTrigger("RuningDown");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
                case Direction.DIAGONAL_UP_LEFT:
                case Direction.DIAGONAL_DOWN_LEFT:
                case Direction.LEFT:
                    animator.SetTrigger("RuningLeft");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 90);
                    break;
                case Direction.DIAGONAL_DOWN_RIGHT:
                case Direction.DIAGONAL_UP_RIGHT:
                case Direction.RIGHT:
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

                case Direction.NONE:
                    animator.SetTrigger("Static");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
                case Direction.UP:
                    animator.SetTrigger("Up");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case Direction.DOWN:
                    animator.SetTrigger("Down");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
                case Direction.DIAGONAL_UP_LEFT:
                case Direction.DIAGONAL_DOWN_LEFT:
                case Direction.LEFT:
                    animator.SetTrigger("Left");
                    flashlight.transform.rotation = Quaternion.Euler(0, 0, 90);
                    break;
                case Direction.DIAGONAL_DOWN_RIGHT:
                case Direction.DIAGONAL_UP_RIGHT:
                case Direction.RIGHT:
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
