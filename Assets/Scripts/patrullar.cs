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
            if (isdoor)
            {
                target = Vector2.zero;
                transform.position = enlace.GetTeleportPosition();
                StartCoroutine(BuscarSiguientePathCorutina());
                isdoor = false;
            }
            else
            {
                PathOrDoor();
            }
        }
    }
    private IEnumerator BuscarSiguientePathCorutina()
    {
        // Espera 0.5 segundos
        yield return new WaitForSeconds(0.5f);

        // Acción a ejecutar después de la espera
        PathOrDoor();
    }
    private void PathOrDoor()
    {
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
            target = enlace.gameObject.transform.position;
            isdoor = true;
        }

    }
}

