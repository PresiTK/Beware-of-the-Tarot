using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject image;

    [SerializeField] private float deactivateTime = 2.0f;
    [SerializeField] private float currentTime = 0;
    private bool textActive;
    private bool mensaje;
    public CharacterMovement player;
    // Start is called before the first frame update
    void Start()
    {
        textActive = false;
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!textActive)
        {
            if (Input.GetKeyDown(KeyCode.E) && textActive == false)
            {
                if (mensaje)
                {
                    text.SetActive(true);
                    textActive = true;
                    currentTime = deactivateTime;
                    player.isSearching = true;

                }
            }
        }
        else if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                player.isSearching = false;
                textActive = false;
                text.SetActive(false);
                player.isSearching = false;

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            image.SetActive(true);
            mensaje = true;
            Debug.Log("Deberia mensaje estar a true");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            image.SetActive(false);
            mensaje = false;
            Debug.Log("Deberia mensaje estar a false");

        }
    }
}
