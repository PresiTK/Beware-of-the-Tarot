using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Back_to_Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start Scene");
    }

}
