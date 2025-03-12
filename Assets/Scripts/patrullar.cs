using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrullar : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private ObtainPathFromRooms Pathscontainer;
    [SerializeField] private float distanciaMinima;
    private int numeroAleatorio;
    private Vector2 target;
    private Enlace enlace;
    private bool isdoor=false;
    private void Start()
    {
        PathOrDoor();
    }

    public void FollowPath()
    {
        if (target == Vector2.zero)
        {
            PathOrDoor();
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position, target, velocidadMovimiento * Time.deltaTime);
        if (Vector2.Distance(transform.position, target) < distanciaMinima)
        {
            PathOrDoor();
        }
    }
    private void PathOrDoor()
    {
        int randomindex = Random.Range(0, 1);
        if (randomindex == 0)
        {
            target = Pathscontainer.RandomPosition();
            isdoor = false;
        }
        else
        {
            enlace = Pathscontainer.RandomEnlace();
            target = enlace.gameObject.transform.position;
            isdoor = true;
        }

    }
}

