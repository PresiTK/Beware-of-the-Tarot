using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTp : MonoBehaviour
{
    public CharacterMovement ubication;
    public bool Camreplace = false;
    public void TpCam()
    {
        transform.position = ubication.transform.position;
        Camreplace = true;
    }
}
