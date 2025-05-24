using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioSource patrol;
    public AudioSource chase;
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
}
