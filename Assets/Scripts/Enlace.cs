using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlace : MonoBehaviour
{
    public GameObject otherDoor;
    public Vector2 doorOffset = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetTeleportPosition()
    {
        if (otherDoor != null)
        {
            Vector2 position = otherDoor.transform.position;
            return position + doorOffset;
        } 
        else
        {
            return transform.position;
        }
    }
}
