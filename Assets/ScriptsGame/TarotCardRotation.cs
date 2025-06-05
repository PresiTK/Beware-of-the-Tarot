using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarotCardRotation : MonoBehaviour
{
    public GameObject contenidoUI; // Asigna aquí el hijo con RectTransform  
    public GameObject Button;
    public GameObject Button2;
    public CharacterMovement characterMovement; // Asigna aquí el script de movimiento del personaje
    public float velocidadRotacion = 30f;
    private bool rotate = false;
    public bool canContinue=false;
    private CanvasGroup canvasGroup;
    public TarotNextScene tarotNextScene; // Asigna aquí el script de la siguiente escena

    void Start()
    {
        Button2.SetActive(false);
        if (contenidoUI != null)
        {
            canvasGroup = contenidoUI.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = contenidoUI.AddComponent<CanvasGroup>();
            }
        }
    }

    void Update()
    {
        if (rotate)
        {
            float rotY = contenidoUI.transform.localEulerAngles.y;

            // Rotar suavemente hacia 180 en Y  
            if (Mathf.Abs(Mathf.DeltaAngle(rotY, 180f)) > 0.1f)
            {
                float nuevaRotY = Mathf.MoveTowardsAngle(rotY, 180f, velocidadRotacion * Time.deltaTime);
                contenidoUI.transform.localEulerAngles = new Vector3(contenidoUI.transform.localEulerAngles.x, nuevaRotY, contenidoUI.transform.localEulerAngles.z);
            }

            // Si Y está cerca de 180, ocultar el contenido  
            if (Mathf.Abs(Mathf.DeltaAngle(rotY, 90f)) < 1f)
            {
                Button.SetActive(false);
            }
            if (Mathf.Abs(Mathf.DeltaAngle(rotY, 180f)) < 1f)
            {
                Button2.SetActive(true);
            }
        }
    }

    public void StartRotation()
    {
        rotate = true;
        tarotNextScene.CanContinue = true; // Permitir continuar a la siguiente escena
    }
    public void Exit()
    {
        gameObject.SetActive(false);
        characterMovement.paused = false; // Reanudar el movimiento del personaje
    }
}
