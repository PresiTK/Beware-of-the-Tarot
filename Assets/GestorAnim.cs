using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GestotAnim : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public GameObject textbox;

    public Image textboxSprite;
    public Sprite[] spriteRenderers;

    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public TextMeshProUGUI textoTMP;
    private int currentTextIndex = 0;

    public void Start()
        
    {
        textbox.SetActive(false);
        textboxSprite.sprite = spriteRenderers[1];
        audioSource.clip = audioClips[1];
        textoTMP.text = "Sister, thank God you're okay.\r\n\r\n(Press ENTER to Continue)..";
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F8))
        {
            ShowTextBox();
        }
    }
    public void HideTextBox()
    {

        textbox.SetActive(false);
        NextText();
    }
    public void ShowTextBox()
    {
        characterMovement.animationIsDone = false;
        textbox.SetActive(true);
    }
    public void NextText()
    {
        if (currentTextIndex == 0)
        {
            textboxSprite.sprite = spriteRenderers[0];
            audioSource.clip = audioClips[0];

            textoTMP.text = "Wha– What just happened?\r\n\r\n(Press ENTER to Continue).."; // Hermana (0)
            ShowTextBox();
        }
        else if (currentTextIndex == 1)
        {
            textboxSprite.sprite = spriteRenderers[1];
            audioSource.clip = audioClips[1];

            textoTMP.text = "You're safe now. I found you just in time.\r\n\r\n(Press ENTER to Continue).."; // Tú (1)
            ShowTextBox();
        }
        else if (currentTextIndex == 2)
        {
            textboxSprite.sprite = spriteRenderers[0];
            audioSource.clip = audioClips[0];

            textoTMP.text = "We need to go. I don’t want to be here another second.\r\n\r\n(Press ENTER to Continue).."; // Hermana (0)
            ShowTextBox();
        }
        else if (currentTextIndex == 3)
        {
            textboxSprite.sprite = spriteRenderers[1];
            audioSource.clip = audioClips[1];

            textoTMP.text = "I’ve got you. Let’s get out of here.\r\n\r\n(Press ENTER to Continue).."; // Tú (1)
            ShowTextBox();
            characterMovement.animationIsDone = true;
        }


        currentTextIndex++;
    }

}
