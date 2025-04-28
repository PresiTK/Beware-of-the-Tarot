using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlace : MonoBehaviour
{
    public GameObject otherDoor;
    public Vector2 doorOffset = Vector2.zero;


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
