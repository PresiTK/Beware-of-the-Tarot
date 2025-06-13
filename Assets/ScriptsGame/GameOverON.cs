using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverON : MonoBehaviour
{
    // Start is called before the first frame update
    public GameOverScreen gameOverScreen;
    public GameObject gameplayUI;
    public void ScreamerEnded()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.GameOverMenu();
    }
    public void ScreamerEndedMinor()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.GameOverMenu();
    }
}
