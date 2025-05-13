using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if(collision.gameObject.TryGetComponent<CharacterMovement>(out CharacterMovement player))
            {
                if (player.WinIsActive)
                {
                    SceneManager.LoadScene("GameScene");
                }
            }
        }
    }
}
