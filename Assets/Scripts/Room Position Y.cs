using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPositionY : MonoBehaviour
{
    public float positionX;
    public float positionY;
    public bool drawGizmos = true;


    private void OnDrawGizmos()
    {
        if (!drawGizmos) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(new Vector2(positionX, positionY), 1);
    }
}
