using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeAnimation : MonoBehaviour
{
    public float delayPerCharacter = 0.05f;

    private bool continuePlaying = false; // Variable para controlar si se continúa jugando
    private TextMeshProUGUI textMesh;
    public AnimationScript textBoxControl; // Asigna aquí el script de control del cuadro de texto
    private AudioSource audioSource;
    [SerializeField] private int charstoPlay;
    private bool endedSound = false;
    void OnEnable()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
        endedSound = false;
        continuePlaying = false; // Asegúrate de que continuePlaying esté en false al inicio

        if (textMesh != null)
        {
            textMesh.ForceMeshUpdate();
            textMesh.maxVisibleCharacters = 0;
            StartCoroutine(RevealCharacters());
        }
    }
    private void Update()
    {
        if (continuePlaying && Input.GetKeyDown(KeyCode.Return))
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
                    audioSource.Play(); // Reproduce el sonido al revelar cada carácter
                    if (textMesh.text[i + 1] == '(')
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
