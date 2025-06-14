using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimationScript : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public GameObject textbox;

    public Animator hoppyAnimtor;
    public Animator cardAnimator;
    public GameObject card;
    public GameObject hoppy;

    public Image textboxSprite;
    public Sprite[] spriteRenderers;

    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public TextMeshProUGUI textoTMP;
    private int currentTextIndex = 0;

    public void Start()
    {
        textbox.SetActive(false);
        textboxSprite.sprite =spriteRenderers[0];
        audioSource.clip = audioClips[0];
        textoTMP.text = "Hi bro im here how is it going \r\n\r\n(Press ENTER to Continue)..";
        textbox.SetActive(true);
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
            
            textoTMP.text = "Uh Whats hapeninig?.\r\n\r\n(Press ENTER to Continue)..";
            ShowTextBox();
        }
        else if (currentTextIndex == 1)
        {
            textboxSprite.sprite = spriteRenderers[2];
            audioSource.clip = audioClips[2];

            card.SetActive(true);
            textoTMP.text = "Hahahahahahha.\r\n\r\n(Press ENTER to Continue)..";
            ShowTextBox();

        }
        else if (currentTextIndex == 2)
        {
            hoppyAnimtor.SetTrigger("Started");
            textboxSprite.sprite = spriteRenderers[1];
            audioSource.clip = audioClips[1];

            textoTMP.text = "You What do you want.\r\n\r\n(Press ENTER to Continue)..";

            ShowTextBox();

        }
        else if (currentTextIndex == 3)
        {
            textboxSprite.sprite = spriteRenderers[2];
            audioSource.clip = audioClips[2];

            textoTMP.text = "Your Sister .\r\n\r\n(Press ENTER to Continue)..";
            ShowTextBox();
            cardAnimator.SetTrigger("Absorbing");

        }
        else if (currentTextIndex == 4)
        {
            textboxSprite.sprite = spriteRenderers[0];
            audioSource.clip = audioClips[0];

            hoppyAnimtor.SetTrigger("Rolling");
            textoTMP.text = "Please broo help.\r\n\r\n(Press ENTER to Continue)..";
            hoppyAnimtor.SetTrigger("Absorb");
            ShowTextBox();

        }
        else if(currentTextIndex == 5)
        {
            textboxSprite.sprite = spriteRenderers[1];
            audioSource.clip = audioClips[1];

            textoTMP.text = "Leave my sister alone\r\n\r\n(Press ENTER to Continue)..";
            ShowTextBox();
        }
        else if (currentTextIndex == 6)
        {
            textboxSprite.sprite = spriteRenderers[2];
            audioSource.clip = audioClips[2];

            textoTMP.text = "Thats imposible, defeat me and your sister will be free.\r\n\r\n(Press ENTER to Continue)..";
            ShowTextBox();
        }
        else if (currentTextIndex == 7)
        {
            textboxSprite.sprite = spriteRenderers[1];
            audioSource.clip = audioClips[1];

            textoTMP.text = "Please stop.\r\n\r\n(Press ENTER to Continue)..";
            ShowTextBox();
            cardAnimator.SetTrigger("bye");
        }

        currentTextIndex++;
    }
    public void DisableSister()
    {
        hoppy.SetActive(false);
    }
    public void DisableCard()
    {
        card.SetActive(false);
        characterMovement.animationIsDone = true;
    }
}
