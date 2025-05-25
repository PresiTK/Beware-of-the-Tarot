using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public static event Action OnWin;
    public static event Action<bool> OnCardNotFound;
    public static event Action<bool> OnCardFound;


    [SerializeField] private GameObject image;

    [SerializeField] private float deactivateTime = 4.0f;
    [SerializeField] private float currentTime = 0;
    private bool textActive;
    private bool mensaje;
    public bool winCondition;
    public AudioSource search;
    public AudioSource cardFound;
    public CharacterMovement player;
    // Start is called before the first frame update
    void Start()
    {
        textActive = false;
        search.Stop();
        cardFound.Stop();
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
                    if (!winCondition)
                    {
                        search.Play();
                        DisplayText();
                    }
                    else
                    {
                        CardFound();
                        cardFound.Play();
                        player.WinIsActive = true;
                    }
                }   
            }
        }
        else if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                HideText();
            }
        }
    }
    private void CardFound()
    {
        OnCardFound?.Invoke(true);
        textActive = true;
        currentTime = deactivateTime;
        player.isSearching = true;

    }
    private void DisplayText()
    {
        OnCardNotFound?.Invoke(true);
        textActive = true;
        currentTime = deactivateTime;
        player.isSearching = true;
    }
    private void HideText()
    {
        player.isSearching = false;
        textActive = false;
        OnCardNotFound?.Invoke(false);
        OnCardFound?.Invoke(false);

        player.isSearching = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            HideText();
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
