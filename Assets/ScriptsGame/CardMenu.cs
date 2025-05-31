using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMenu : MonoBehaviour
{
    public GameObject cardMenuCanvas;
    private bool isCardMenuAvailable = false;
    private void Start()
    {
        cardMenuCanvas.SetActive(false);
    }
    void Update()
    {
        if (isCardMenuAvailable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                cardMenuCanvas.SetActive(true);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCardMenuAvailable = !isCardMenuAvailable;
        }
    }
}
