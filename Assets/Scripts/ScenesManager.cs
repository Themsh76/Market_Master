using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Macht es m�glich alle Klassen f�r Scenen zu erreichen

public class ScenesManager : MonoBehaviour
{
   public static ScenesManager Instance;     // Leitet eine Instanz von SceneManager ab

    private void Awake()    // Funktion die erm�glicht, dass man �berall auf Instance zugreifen kann
    {
        Instance = this;
    }

    public enum Scene
    {
        StartScreen,        // Aufz�hlung von Scenes f�r sp�tere Verwendung -> Wichtig gleiche Reihenfolge wie in den Build settings
        MainScreen,
        Ressource
    }

    public void LoadScene(Scene scene)      // Funktion die eine bestimmte Scene laden l�sst
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGame()       // Funktion, die den Mainscreen l�dt
    {
        SceneManager.LoadScene(Scene.MainScreen.ToString());
    }

    public void LoadRessoruce()     // Funktion, die den Ressourcenscreen l�dt
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(Scene.Ressource.ToString());
    }

    public void LoadMainScreen()    // Funktion, die den Mainscreen l�dt
    {
        SceneManager.LoadScene(Scene.MainScreen.ToString());
    }

    public void LoadStartScreen()       // Funktion, die den Startscreen l�dt
    {
        SceneManager.LoadScene(Scene.StartScreen.ToString());
    }



}
