using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CameraMovement : MonoBehaviour
{
    [Header("Target Info")]
    public GameObject target = null;

    private Vector2 lastTargetPosition;

    [Header("Parameters")]
    public bool isInRoom = true;
    public float speed;

    private void Start()
    {
        lastTargetPosition.x = target.transform.position.x;
        transform.position = target.transform.position;
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if(target != null)
        {
            lastTargetPosition.x = target.transform.position.x;
            transform.position = Vector2.Lerp(transform.position, lastTargetPosition, speed * Time.deltaTime);
        }
    }

    public void TeleportToRoom(Vector2 roomPosition)
    {
        Vector2 newPosition = new Vector2(
            target.transform.position.x,
            roomPosition.y
        );
        transform.position = newPosition;
        lastTargetPosition = newPosition;
        isInRoom = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Room")
        {
            if (isInRoom)
            {
                if (collision.gameObject.TryGetComponent<RoomPositionY>(out RoomPositionY roomPositionY))
                {
                    TeleportToRoom(
                        new Vector2(
                            roomPositionY.positionX, 
                            roomPositionY.positionY
                            )
                       
                        );
                }
            }
        }
    }


}
