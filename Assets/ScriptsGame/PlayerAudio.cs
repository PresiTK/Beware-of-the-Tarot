using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource steps;
    public AudioSource card;
    public AudioSource door;
    public AudioSource flashlifht;
    public AudioSource flashlightActive;


    public void StepsOn()
    {
        steps.PlayOneShot(steps.clip);
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
    public void DoorOpen()
    {
        door.Play();
    }
    public void FlashlightOn()
    {
        flashlifht.Play();
    }
    public void LightActive()
    {
        flashlightActive.Play();
    }
    public void LightNo()
    {
        flashlightActive.Stop();
    }
}
