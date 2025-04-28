using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinControl : MonoBehaviour
{
    [SerializeField] private Interaction[] drawers;
    void Start()
    {
        if (drawers == null)
        {
            return;
        }
        int RandomNumber=Random.Range(0,drawers.Length);
        drawers[RandomNumber].winCondition = true;
    }
}
