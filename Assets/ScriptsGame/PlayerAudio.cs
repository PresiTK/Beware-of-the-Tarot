using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource steps;
    public AudioSource card;

    public void StepsOn()
    {
        steps.Play();
    }
    public void RunOn()
    {
        steps.pitch = 1.5f;
    }
    public void RunOff()
    {
        steps.pitch = 1f;
    }
    public void StepsOff()
    {
        steps.Stop();
    }
    public void TarotCardObtained()
    {
        card.Play();
    }

}