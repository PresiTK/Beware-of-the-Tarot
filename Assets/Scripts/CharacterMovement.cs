using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { NONE, UP, DOWN, LEFT, RIGHT };
public class CharacterMovement : MonoBehaviour
{
    public float currentSpeedX;
    public float currentSpeedY;
    public float speedX = 1f;
    public float speedY = 1f;
    public float runningSpeedX = 1.5f;
    public float runningSpeedY = 1.5f;

    Rigidbody2D rb2d;

    public Direction direction = Direction.NONE;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirection();
    }

    private void FixedUpdate()
    {
        //Siempre comprobar si los componentes existen antes de usarlos
        if (rb2d == null) { return; } //Si no existe me piro y no hago nada, me ahorro cálculos

        //Separamos lógica de física
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
            default:
                break;
        }

        //Recordad multiplicar por deltaTime para que sea frame-dependent
        rb2d.velocity = new Vector2(hInput * currentSpeedX * Time.fixedDeltaTime, vInput * currentSpeedY * Time.fixedDeltaTime);
    }

    private void UpdateDirection()
    {
        //Separamos lógica de física
        direction = Direction.NONE;
        int horizontal = 0;
        int vertical = 0;
        if (Input.GetKey(KeyCode.UpArrow)){     vertical += 1;}
        if (Input.GetKey(KeyCode.DownArrow)){   vertical -= 1;}
        
        if (Input.GetKey(KeyCode.LeftArrow)){   horizontal -= 1;}
        if (Input.GetKey(KeyCode.RightArrow)){  horizontal += 1;}

        if (vertical > 0){
            direction = Direction.UP;
        }else if (vertical < 0){
            direction = Direction.DOWN;
        }

        if (horizontal < 0){
            direction = Direction.LEFT;
        }else if (horizontal > 0){
            direction = Direction.RIGHT;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeedX = speedX * runningSpeedX;
            currentSpeedY = speedY * runningSpeedY;
        }
        else
        {
            currentSpeedX = speedX;
            currentSpeedY = speedY;
        }
    }
}
