using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public float delayPerCharacter = 0.05f;

    private bool continuePlaying = false; // Variable para controlar si se continúa jugando
    private TextMeshProUGUI textMesh;
    public TextBoxControl textBoxControl; // Asigna aquí el script de control del cuadro de texto

    void OnEnable()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

        if (textMesh != null)
        {
            textMesh.ForceMeshUpdate();
            textMesh.maxVisibleCharacters = 0;
            StartCoroutine(RevealCharacters());
        }
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

        for (int i = 0; i <= totalCharacters; i++)
        {
            textMesh.maxVisibleCharacters = i;
            yield return new WaitForSeconds(delayPerCharacter);
        }

        continuePlaying = true;
    }
}
