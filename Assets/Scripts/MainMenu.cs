using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string nombreEscenaJuego = "SampleScene";

    // Método para iniciar el juego
    public void Jugar()
    {
        Debug.Log("Iniciando el juego...");
        SceneManager.LoadScene(nombreEscenaJuego);
    }

    // Método para mostrar opciones
    public void Opciones()
    {
        Debug.Log("Abriendo menú de opciones...");
    }

    // Método para salir del juego
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();

        // Si estás en el editor de Unity
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
}
