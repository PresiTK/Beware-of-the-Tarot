using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrullar : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private ObtainPathFromRooms Pathscontainer;
    [SerializeField] private float distanciaMinima;
    public DoorInteraction position;
    private int numeroAleatorio;
    public Vector2 target;
    private Enlace enlace;
    private bool isdoor=false;
    private bool iswaiting=false;
    private void Start()
    {
        PathOrDoor();
    }
    
public void FollowPath()
    {
        if (Pathscontainer.Recall)
        {
            if (target == Vector2.zero)
            {
                PathOrDoor();
                return;
            }
            transform.position = Vector2.MoveTowards(transform.position, target, velocidadMovimiento * Time.deltaTime);
            if (Vector2.Distance(transform.position, target) < distanciaMinima)
            {
                if (isdoor)
                {
                    target = Vector2.zero;
                    transform.position = enlace.GetTeleportPosition();
                    isdoor = false;
                    Pathscontainer.Recall = false;
                }
                else
                {
                    PathOrDoor();
                }
            }
        }
    }
  
    private void PathOrDoor()
    {
        if (!iswaiting)
        {
            StartCoroutine(WaitforPath());
        }
    }
    IEnumerator WaitforPath()
    {
        iswaiting = true;
        yield return new WaitForSeconds(1f);
        int randomnumber;
        randomnumber = Random.Range(0, 10);
        if (randomnumber < 7)
        {
            target = Pathscontainer.RandomPosition();
            isdoor = false;
        }
        else
        {
            enlace = Pathscontainer.RandomEnlace();
            if (enlace != null && enlace.gameObject != null)
            {
                target = enlace.gameObject.transform.position;
            }
            isdoor = true;
        }
        iswaiting = false;

    }
    //public void FollowDoorPlayer()
    //{
    //    int value = 0;
    //    while (position.teleportPosition != enlace)
    //    {
    //        enlace= Pathscontainer.HardcodedEnlace(value);
    //        value++;
    //    }
    //}
}

