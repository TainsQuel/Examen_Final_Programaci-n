using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Escena_1()
    {
        SceneManager.LoadScene("Primera_Escena");
    }
    public void Escena_2()
    {
        SceneManager.LoadScene("Segunda_Escena");
    }

    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}
