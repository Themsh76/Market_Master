using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStartScreen : MonoBehaviour
{
    [SerializeField] Button _StartScreen;       // Erstellt Feld, wo man einen Button ausw�hlen kann, aufden das Programm zutrifft

    void Start()
    {
        _StartScreen.onClick.AddListener(LoadStartScreen);      // Wartet darauf, dass geklickt wird und f�hrt dann LoadStartScreen aus
    }

    private void LoadStartScreen()  // Funktion die die Funktion LoadStartScreen ausf�hrt
    {
        ScenesManager.Instance.LoadStartScreen();
    }

}
