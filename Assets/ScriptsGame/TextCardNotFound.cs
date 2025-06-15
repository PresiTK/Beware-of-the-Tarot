using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCardNotFound : MonoBehaviour
{
    [SerializeField] private GameObject text;
    void Start()
    {
        text.SetActive(false);
    }
    private void OnEnable()
    {
        Interaction.OnCardNotFound += ActivateText;
    }
    private void OnDisable()
    {
        Interaction.OnCardNotFound -= ActivateText;
    }

    private void ActivateText(bool obj)
    {
        text.SetActive(obj);
    }
}
