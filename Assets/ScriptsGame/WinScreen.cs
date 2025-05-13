using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private GameObject Wincanva;

    private void OnEnable()
    {
        Interaction.OnWin += WinMenu;
    }
    private void OnDisable()
    {
        Interaction.OnWin -= WinMenu;
    }
    private void Start()
    {
        Wincanva.SetActive(false);
    }
    public void WinMenu()
    {
        Wincanva.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
