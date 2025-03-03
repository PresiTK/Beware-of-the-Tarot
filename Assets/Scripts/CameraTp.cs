using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTp : MonoBehaviour
{
    public CharacterMovement ubication;
    public void TpCam()
    {
        transform.position = ubication.transform.position;
    }
}
