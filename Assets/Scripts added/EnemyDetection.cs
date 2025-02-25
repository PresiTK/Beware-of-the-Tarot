using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public bool vision = false;
    public GameObject player;
    public float detectionRange = 5f;
    public Hiding hided;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.transform.position) >= detectionRange)
            {
                vision = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (!hided.notseen)
            {
                Debug.Log("ESTOY VIENDOTE");
                vision = true;
            }
            if(hided.notseen)
            {
                vision = false;
                Debug.Log("Por probar");
            }
        }
    }
    void OnTriggerExist2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            vision = false;
        }
    }

}
