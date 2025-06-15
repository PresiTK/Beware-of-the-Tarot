using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCardFound : MonoBehaviour
{
    [SerializeField] private GameObject text;
    void Start()
    {
        text.SetActive(false);
    }
    private void OnEnable()
    {
        Interaction.OnCardFound += ActivateText;
    }
    private void OnDisable()
    {
        Interaction.OnCardFound -= ActivateText;
    }
    private void ActivateText(bool obj)
    {
        text.SetActive(obj);
    }
}
