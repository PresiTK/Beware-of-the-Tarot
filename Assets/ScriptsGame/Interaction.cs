using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private GameObject image;

    [SerializeField] private float deactivateTime = 4.0f;
    [SerializeField] private float currentTime = 0;
    private bool textActive;
    private bool mensaje;
    public bool winCondition;
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    public CharacterMovement player;
    // Start is called before the first frame update
    void Start()
    {
        textActive = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
        audioSource.clip = audioClips[1];
        audioSource.Stop();

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
                        audioSource.clip = audioClips[1];
                        audioSource.Play();
                        DisplayText();
                    }
                    else
                    {
                        CardFound();
                        audioSource.clip = audioClips[0];
                        audioSource.Play();
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
        textActive = true;
        currentTime = deactivateTime;
        player.isSearching = true;
    }
    private void DisplayText()
    {
        textActive = true;
        currentTime = deactivateTime;
        player.isSearching = true;
    }
    private void HideText()
    {
        player.isSearching = false;
        textActive = false;
        player.isSearching = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            audioSource.volume = 1; // Set volume to 50%
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
