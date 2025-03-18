using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObtainPathFromRooms : MonoBehaviour
{
    [SerializeField]
    private Transform[] transforms;
    private Enlace[] enlaces;
    public bool Recall=false;
    private bool onetime = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (onetime)
        {
            if (collision.gameObject.tag == "Room")
            {
                RoomPaths roomPaths = collision.gameObject.GetComponent<RoomPaths>();
                if (roomPaths != null)
                {
                    enlaces = roomPaths.enlaces;
                    transforms = roomPaths.positions;
                    Recall = true;
                    onetime = false; ;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Room")
        {
            transforms = null;
            enlaces = null;
            Recall = false;
            onetime = true;
        }
    }
    public Vector2 RandomPosition()
    {
        if(transforms == null || transforms.Length==0)
        {
            return Vector2.zero;
        }
        int randomindex=Random.Range(0, transforms.Length);

        return transforms[randomindex].position;
    }
    public Enlace RandomEnlace()
    {
        if (enlaces == null || enlaces.Length == 0)
        {
            return null;
        }
        int randomindex = Random.Range(0, enlaces.Length);

        return enlaces[randomindex];
    }
}
