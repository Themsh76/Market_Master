using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStartScreen : MonoBehaviour
{
    [SerializeField] Button _StartScreen;       // Erstellt Feld, wo man einen Button auswählen kann, aufden das Programm zutrifft

    void Start()
    {
        _StartScreen.onClick.AddListener(LoadStartScreen);      // Wartet darauf, dass geklickt wird und führt dann LoadStartScreen aus
    }

    private void LoadStartScreen()  // Funktion die die Funktion LoadStartScreen ausführt
    {
        ScenesManager.Instance.LoadStartScreen();
    }

}
