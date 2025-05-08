using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject image;


    private bool hide = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hide && player.TryGetComponent<CharacterHide>(out CharacterHide characterHide))
        {
            characterHide.Hide();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            player = collision.gameObject;
            image.SetActive(true);
            hide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            player = null;
            hide = false;
            image.SetActive(false);
        }
    }


}
