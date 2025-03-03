using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Direction { NONE, UP, DOWN, LEFT, RIGHT , DIAGONAL_UP_RIGHT, DIAGONAL_UP_LEFT, DIAGONAL_DOWN_RIGHT, DIAGONAL_DOWN_LEFT };
public class CharacterMovement : MonoBehaviour
{
    public float speedX = 1;
    public float speedY = 1;
    public bool light_flash;

    Rigidbody2D rb2d;
    SpriteRenderer sprRender;

    public Direction direction = Direction.NONE;

    public float currShootTime = 0;
    public float shootCadenceTime = 2.0f;

    public bool isHiding = false;
    private bool pressingHide = false;
    
    // Start is called before the first frame update
    void Start()
    {
        light_flash = false;
        rb2d = GetComponent<Rigidbody2D>();
        sprRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirection();
        Shoot();

        if (Input.GetKeyDown(KeyCode.E)){
            pressingHide = !pressingHide;

        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            light_flash = !light_flash;
        }
    }

    private void FixedUpdate()
    {
        //Siempre comprobar si los componentes existen antes de usarlos
        if (rb2d == null) { return; } //Si no existe me piro y no hago nada, me ahorro c�lculos

        //Separamos l�gica de f�sica
        float hInput = 0;
        float vInput = 0;

        switch (direction){
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

        rb2d.velocity = new Vector2(hInput * speedX * Time.fixedDeltaTime, vInput * speedY * Time.fixedDeltaTime);
    }

    private void UpdateDirection()
    {
        //Separamos l�gica de f�sica
        direction = Direction.NONE;
        if(isHiding) { return; }

        int horizontal = 0;
        int vertical = 0;

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)) { vertical += 1; horizontal += 1; Debug.Log("EY EY"); }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)) { vertical -= 1; horizontal -= 1; }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)) { vertical += 1; horizontal -= 1; }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)) { vertical -= 1; horizontal += 1; }
        else
        {
            if (Input.GetKey(KeyCode.DownArrow)) { vertical -= 1; }
            if (Input.GetKey(KeyCode.UpArrow)) { vertical += 1; }
            if (Input.GetKey(KeyCode.LeftArrow)) { horizontal -= 1; }
            if (Input.GetKey(KeyCode.RightArrow)) { horizontal += 1; }
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
                Debug.Log("OOOO");
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
    }

    private void Shoot(){   
        if (Input.GetKeyDown(KeyCode.Space)){//Haced esto en lugar de una corrutina pls :(
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

    private void HideInPlace(bool hide) {
        isHiding = hide;
        if(sprRender != null)
        {
            Color col = sprRender.color;
            if(isHiding)
            {
                col.a = 0.5f;
            }
            else
            {
                col.a = 1f;
            }
            sprRender.color = col;
        }
    }

}
