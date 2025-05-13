using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioSource enemySteps;
    public void Steps()
    {
        enemySteps.Play();
    }
    public void Run()
    {
        enemySteps.pitch = 1.4f;
    }
    public void Walk()
    {
        enemySteps.pitch = 1f;
    }
    public void StepsOff()
    {
        enemySteps.Stop();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
