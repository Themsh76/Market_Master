using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Macht es möglich alle Klassen für Scenen zu erreichen

public class ScenesManager : MonoBehaviour
{
   public static ScenesManager Instance;     // Leitet eine Instanz von SceneManager ab

    private void Awake()    // Funktion die ermöglicht, dass man überall auf Instance zugreifen kann
    {
        Instance = this;
    }

    public enum Scene
    {
        StartScreen,        // Aufzählung von Scenes für spätere Verwendung -> Wichtig gleiche Reihenfolge wie in den Build settings
        MarketScreen,
        WoodScreen,
        StoneScreen
    }

    public void LoadScene(Scene scene)      // Funktion die eine bestimmte Scene laden lässt
    {
        SceneManager.LoadScene(scene.ToString());
        
    }

    public void LoadNewGame()       // Funktion, die den Mainscreen lädt
    {
        SceneManager.LoadScene(Scene.MarketScreen.ToString());
    }

    public void LoadRessoruce()     // Funktion, die den Ressourcenscreen lädt
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(Scene.WoodScreen.ToString());
    }

    public void LoadMainScreen()    // Funktion, die den Mainscreen lädt
    {
        SceneManager.LoadScene(Scene.MarketScreen.ToString());
    }

    public void LoadStartScreen()       // Funktion, die den Startscreen lädt
    {
        SceneManager.LoadScene(Scene.StartScreen.ToString());
    }

    public void LoadStoneScreen()
    {
        SceneManager.LoadScene(Scene.StoneScreen.ToString());
    }
}
