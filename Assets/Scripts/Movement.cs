using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Movement : MonoBehaviour
{
    SpriteRenderer sprRender;

    public float alpha = 1.0f;
    public GameObject target = null;
    public CameraTp replace;
    private bool isHiding = false;
    private bool pressingHide = false;

    private Vector2 targetPosition;
    private Vector2 CurrentPosition;
    public bool isInRoom = true;

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
            if (!replace.Camreplace)
            {
                targetPosition.x = target.transform.position.x;
                CurrentPosition = transform.position;
            }
            else
            {
                targetPosition= replace.transform.position;
                CurrentPosition= targetPosition;
                replace.Camreplace = false;
            }
        }
        transform.position=Vector2.Lerp(CurrentPosition, targetPosition, alpha * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.F))
        {
            pressingHide = !pressingHide;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Room")
        {
            if (isInRoom)
            {
                Debug.Log("Te detecto");
                Vector3 position = collision.gameObject.transform.position;
                position.x = transform.position.x;
                transform.position = position;
                isInRoom = false;
            }
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