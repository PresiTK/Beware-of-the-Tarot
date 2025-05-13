using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPositionY : MonoBehaviour
{
    public float positionX;
    public float positionY;

    private void Awake()
    {
        positionX = transform.position.x;
        positionY = transform.position.y;
    }
}
