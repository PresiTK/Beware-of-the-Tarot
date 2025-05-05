using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartMenu : MonoBehaviour
{
    public AudioMixer AudioMixer;

    public void playGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void quitGame()
    {
        Application.Quit();
    }

    public void SetVolume  (float volume)
    {
        AudioMixer.SetFloat("volume", volume);
    }
}
