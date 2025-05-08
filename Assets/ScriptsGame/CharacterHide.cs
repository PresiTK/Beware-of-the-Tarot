using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHide : MonoBehaviour
{
    public bool hided=false;
    public float characterYpos;
    public float tpYpos = 20000;

    private void Update()
    {
        if (hided && Input.GetKeyDown(KeyCode.E))
        {
            UnHide();
        }
    }
    public void Hide()
    {
        characterYpos = transform.position.y;
        transform.position = new Vector2(transform.position.x, tpYpos);
        hided = true;
        if(TryGetComponent<CharacterMovement>(out CharacterMovement characterMovement))
        {
            characterMovement.isHiding = true;
            characterMovement.rb2d.velocity=Vector2.zero;

        }
    }
    private void UnHide()
    {
        transform.position = new Vector2(transform.position.x, characterYpos);
        hided = false;
        if (TryGetComponent<CharacterMovement>(out CharacterMovement characterMovement))
        {
            characterMovement.isHiding = false;
        }
    }
}
