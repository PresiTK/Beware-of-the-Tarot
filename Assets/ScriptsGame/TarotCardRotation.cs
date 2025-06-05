using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarotCardRotation : MonoBehaviour
{
    public GameObject contenidoUI; // Asigna aquí el hijo con RectTransform  
    public GameObject Button;
    public float velocidadRotacion = 30f;
    private bool rotate = false;

    private CanvasGroup canvasGroup;

    void Start()
    {
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
            else
            {
                if (canvasGroup != null && canvasGroup.alpha != 1)
                    canvasGroup.alpha = 1;
            }
        }
    }

    public void StartRotation()
    {
        rotate = true;
    }
}
