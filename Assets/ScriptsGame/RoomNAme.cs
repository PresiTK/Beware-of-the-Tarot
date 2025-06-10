using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNAme : MonoBehaviour
{
    public string room;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Room"))
        {
            room=collision.gameObject.name;
            Debug.Log("Entered room: " + room);
        }
    }
}
