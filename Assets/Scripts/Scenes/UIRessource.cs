using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRessource : MonoBehaviour
{
    [SerializeField] Button _RessourceScreen;       // Erstellt Feld, wo man einen Button ausw�hlen kann, aufden das Programm zutrifft

    void Start()
    {
        _RessourceScreen.onClick.AddListener(LoadRessourceScreen);      // Wartet darauf, dass geklickt wird und f�hrt dann LoadRessourceScreen aus
        
    }

    private void LoadRessourceScreen()  // Funktion die die Funktion LoadRessource ausf�hrt
    {
        ScenesManager.Instance.LoadRessoruce();
    }
}
