using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainScreen : MonoBehaviour
{
    [SerializeField] Button _mainScreen;       // Erstellt Feld, wo man einen Button ausw�hlen kann, aufden das Programm zutrifft 

    void Start()
    {
        _mainScreen.onClick.AddListener(StartNewGame);     // Wartet darauf, dass geklickt wird und f�hrt dann StartNewGame aus
    }

    private void StartNewGame()      // Funktion die die Funktion LoadNewGame ausf�hrt
    {
        ScenesManager.Instance.LoadNewGame();
        //ScenesManager.Instance.LoadScene(ScenesManager.Scene.MainScreen)  -> So kann man eine bestimmte Scene laden lassen

    }

}
