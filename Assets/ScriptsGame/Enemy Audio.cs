using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{

    public  AudioSource audioSource;
    public AudioClip[] audioClips;
    public AudioSource scream;

    private void Start()
    {
        audioSource.clip = audioClips[0];
        audioSource.Stop();
        scream.Stop();
    }
    public void PatrolOn()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }
    public void PatrolOff()
    {
        audioSource.clip = audioClips[0];
        audioSource.Stop();
    }
    public void ChaseOn()
    {
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }
    public void ChaseOff()
    {
        audioSource.clip = audioClips[1];
        audioSource.Stop();
    }
    public void Scream()
    {
        
        scream.clip = audioClips[2];
        scream.Play();
    }
    public void ScreamOff()
    {
        audioSource.clip = audioClips[2];
        audioSource.Stop();
    }
}
