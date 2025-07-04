using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public float delayPerCharacter = 0.05f;

    private bool continuePlaying = false; // Variable para controlar si se contin�a jugando
    private TextMeshProUGUI textMesh;
    public TextBoxControl textBoxControl; // Asigna aqu� el script de control del cuadro de texto
    private AudioSource audioSource;
    [SerializeField] private int charstoPlay;
    private bool endedSound = false;
    void OnEnable()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
        endedSound = false;

        if (textMesh != null)
        {
            textMesh.ForceMeshUpdate();
            textMesh.maxVisibleCharacters = 0;
            StartCoroutine(RevealCharacters());
        }
        continuePlaying = false; // Aseg�rate de que continuePlaying est� en false al inicio
    }
    private void Update()
    {
        if(continuePlaying&&Input.GetKeyDown(KeyCode.Return))
        {
            textBoxControl.HideTextBox();
        }

    }
    IEnumerator RevealCharacters()
    {
        int totalCharacters = textMesh.textInfo.characterCount;
        int charIndex = 0;
        for (int i = 0; i <= totalCharacters; i++)
        {
            textMesh.maxVisibleCharacters = i;

            if (charIndex % charstoPlay == 0)
            {
                if (!endedSound)
                {
                    audioSource.Play(); 
                    if (textMesh.text[i+1] == '(')
                    {
                        
                        endedSound = true;
                    }
                }

            }
            yield return new WaitForSeconds(delayPerCharacter);
        }

        continuePlaying = true;
    }
}
