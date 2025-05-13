using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private ActionsMap actionsMap;
    public static event Action OnInteract;
    private void Awake()
    {
        actionsMap = new ActionsMap();
        actionsMap.Enable();
        actionsMap.Player.Enable();
    }
    private void OnEnable()
    {
        actionsMap.Player.Interact.performed += HandleInteract;
    }
    private void OnDisable()
    {
        actionsMap.Player.Interact.performed -= HandleInteract;
    }
    private void HandleInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnInteract?.Invoke();
            Debug.Log("Interact action performed");
        }
    }
}
