using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioSource patrol;
    public AudioSource chase;
    public AudioSource scream;

    private void Start()
    {
        patrol.Stop();
        chase.Stop();
        scream.Stop();
    }
    public void PatrolOn()
    {
        patrol.Play();
    }
    public void PatrolOff()
    {
        patrol.Stop();
    }
    public void ChaseOn()
    {
        chase.Play();
    }
    public void ChaseOff()
    {
        chase.Stop();
    }
    public void Scream()
    {
        scream.Play();
    }
    public void ScreamOff()
    {
        scream.Stop();
    }
}
