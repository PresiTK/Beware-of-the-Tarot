using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipTutorial : MonoBehaviour
{
    public void Skip()
    {
        SceneManager.LoadScene("TarotSceneObtained");
    }
    public void NoSkip()
    {
        SceneManager.LoadScene("Tutorial Scene");
    }
}
