using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Flashlight : MonoBehaviour
{
    public void Rotation(float num)
    {
        transform.Rotate(0, 0, num);
    }
}
