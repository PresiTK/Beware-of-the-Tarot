using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private float deactivateTime = 2.0f;
    [SerializeField] private float currentTime = 0;
    private bool textActive;
    // Start is called before the first frame update
    void Start()
    {
        textActive = false;
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!textActive)
        {
            if (Input.GetKeyDown(KeyCode.E) && textActive == false)
            {
                text.SetActive(true);
                textActive = true;
                currentTime = deactivateTime;
            }
        }
        else if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                textActive = false;
                text.SetActive(false);
            }
        }
    }
}
