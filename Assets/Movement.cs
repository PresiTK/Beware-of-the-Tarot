using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Movement : MonoBehaviour
{
    public float alpha = 1.0f;
    public GameObject target = null;

    private Vector2 targetPosition;
    private Vector2 CurrentPosition;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
