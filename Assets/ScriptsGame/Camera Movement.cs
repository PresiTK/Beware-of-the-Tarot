using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CameraMovement : MonoBehaviour
{
    [Header("Target Info")]
    public GameObject target = null;

    private Vector2 lastTargetPosition;

    public float margin=6.8f;
    [Header("Camera Limits")]
    public float minX;
    public float maxX;

    [Header("Parameters")]
    public bool isInRoom = true;
    public float speed;

    private void Start()
    {
        lastTargetPosition.x = target.transform.position.x;
        transform.position = target.transform.position;

        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Current Scene: " + sceneName);
        if (sceneName == "GameScene")
        {
            minX = -7f;
            maxX = 7f;
        }
        else if (sceneName == "Tutorial Scene")
        {
            minX = -57f;
            maxX = -43f;
        }
    }
    private void FixedUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if (target != null)
        {
            lastTargetPosition.x = target.transform.position.x;

            // Calcula nueva posición con interpolación
            Vector2 targetPos = Vector2.Lerp(transform.position, lastTargetPosition, speed * Time.deltaTime);

            // Limita la posición en X
            targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);

            // Aplica nueva posición
            transform.position = targetPos;
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
        minX = roomPosition.x - margin;
        maxX = roomPosition.x + margin;
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

                    float roomCenterX = roomPositionY.positionX;
                    float halfWidth = (maxX - minX) / 2f;

                    minX = roomCenterX - halfWidth;
                    maxX = roomCenterX + halfWidth;
                }
            }
        }
    }



}
