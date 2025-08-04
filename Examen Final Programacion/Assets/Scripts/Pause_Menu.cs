using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{

    [SerializeField] private GameObject PauseButtom;
    [SerializeField] private GameObject PauseMenu;
    public void Pause()
    {
        Time.timeScale = 0f;
        PauseButtom.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PauseButtom.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void Escena_1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Primera_Escena");
    }
    public void Escena_2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Segunda_Escena");
    }

    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}
