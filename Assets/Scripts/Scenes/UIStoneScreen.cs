using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStoneScreen : MonoBehaviour
{
    [SerializeField] Button _StoneScreen;       // Erstellt Feld, wo man einen Button auswählen kann, aufden das Programm zutrifft

    void Start()
    {
        _StoneScreen.onClick.AddListener(LoadStone);      // Wartet darauf, dass geklickt wird und führt dann LoadRessourceScreen aus

    }

    private void LoadStone()  // Funktion die die Funktion LoadRessource ausführt
    {
        ScenesManager.Instance.LoadStoneScreen();
    }
}
