using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStartScreen : MonoBehaviour
{
    [SerializeField] Button _newGame;       // Erstellt Feld, wo man einen Button auswählen kann, aufden das Programm zutrifft 

    void Start()
    {
        _newGame.onClick.AddListener(StartNewGame);     // Wartet darauf, dass geklickt wird und führt dann StartNewGame aus
    }

    private void StartNewGame()      // Funktion die die Funktion LoadNewGame ausführt
    {
        ScenesManager.Instance.LoadNewGame();
        //ScenesManager.Instance.LoadScene(ScenesManager.Scene.MainScreen)  -> So kann man eine bestimmte Scene laden lassen
    }

}
