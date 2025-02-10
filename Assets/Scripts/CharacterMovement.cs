using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { NONE, UP, DOWN, LEFT, RIGHT };
public class CharacterMovement : MonoBehaviour
{
    public float speedX = 1;
    public float speedY = 1;

    Rigidbody2D rb2d;

    public Direction direction = Direction.NONE;

    public float currShootTime = 0;
    public float shootCadenceTime = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirection();
        Shoot();
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
        rb2d.velocity = new Vector2(hInput * speedX * Time.fixedDeltaTime, vInput * speedY * Time.fixedDeltaTime);
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
}
