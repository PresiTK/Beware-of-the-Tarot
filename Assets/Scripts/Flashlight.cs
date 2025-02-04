using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public CharacterMovement light_on;

    Rigidbody2D rb2d;
    SpriteRenderer sprRender;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sprRender != null)
        {
            Color col = sprRender.color;
            if (light_on.light_flash)
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
