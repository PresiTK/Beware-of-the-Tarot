using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBoxControl : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public GameObject textbox;
    public GameObject TutorialMove;
    public TextMeshProUGUI textoTMP;
    private int currentTextIndex = 0;

    public void Start()
    {
        TutorialMove.SetActive(false);
        textoTMP.text = "Welcome to Beware of the Tarot! I'm Skully, and I'm here to teach you how to play!\r\n\r\n(Press ENTER to Continue)..";
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
        if (!TutorialMove.activeSelf)
        {
            TutorialMove.SetActive(true);
        }
        characterMovement.animationIsDone = true;
        textbox.SetActive(false);
        NextText();
    }
    public void ShowTextBox()
    {
        characterMovement.animationIsDone=false;
        textbox.SetActive(true);
    }
    public void NextText()
    {
        if (currentTextIndex == 0)
        {
            textoTMP.text = "Use shift to run, but use it wisely, as it drains your stamina.\r\n\r\n(Press ENTER to Continue)..";

        }
        else if (currentTextIndex == 1)
        {
            textoTMP.text = "The Flahslight has a limited battery, so use it wisely.\r\n\r\n(Press ENTER to Continue)..";
        }
        else if(currentTextIndex == 2)
        {
            textoTMP.text = "Use the wardrove to hide from the monsters.\r\n\r\n(Press ENTER to Continue)..";
        }
        else if (currentTextIndex == 3) 
        {
            textoTMP.text = "Search in the boxes to find the Tarot Cards.\r\n\r\n(Press ENTER to Continue)..";
        }
        else if (currentTextIndex == 4)
        {
            textoTMP.text = "Friend, this is a GoodBye, Have fun.\r\n\r\n(Press ENTER to Continue)..";
        }
        currentTextIndex++;
    }
}
