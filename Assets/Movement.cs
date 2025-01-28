using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Movement : MonoBehaviour
{
    SpriteRenderer sprRender;

    public float alpha = 1.0f;
    public GameObject target = null;
    private bool isHiding = false;
    private bool pressingHide = false;

    private Vector2 targetPosition;
    private Vector2 CurrentPosition;

    // Start is called before the first frame update
    void Start()
    {
        sprRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target!= null)
        {
            targetPosition = target.transform.position;
            CurrentPosition = transform.position;
        }
        transform.position=Vector2.Lerp(CurrentPosition, targetPosition, alpha * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.F))
        {
            pressingHide = !pressingHide;
        }
        
    }

    private void HideInElement(bool hide)
    {
        isHiding = hide;
        if (sprRender != null)
        {
            Color col = sprRender.color;
            if (isHiding)
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