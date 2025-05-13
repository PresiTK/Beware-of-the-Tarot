using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class available_ilumination : MonoBehaviour
{
    [SerializeField] private float currentTime = 0;
    public float timeToWait = 2.0f;
    public GameObject light2D;
    private bool lightActive = false;
    private bool isTrigger = false;
    private void Start()
    {
        light2D.SetActive(false);
    }
    private void Update()
    {
        if (isTrigger)
        {
            timerlight();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            light2D.SetActive(true);
            currentTime = timeToWait;
            isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            light2D.SetActive(false);
            isTrigger = false;
        }
    }
    private void timerlight()
    {
        Debug.Log("En el trigger");
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            Debug.Log("currentTime: " + currentTime);
            if (currentTime <= 0)
            {
                currentTime = timeToWait;
                light2D.SetActive(lightActive);
                lightActive = !lightActive;
            }
        }
    }
}
