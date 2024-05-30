using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cardspace;
using TMPro;
using System.Diagnostics;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public TMP_Text goldText;
    public TMP_Text EXPText;
    public TMP_Text Holztext;
    public TMP_Text Steintext;

    void Start()
    {
        // Stelle sicher, dass die Methode aufgerufen wird, wenn das Spiel startet
        UpdateCardDisplay();
    }

    void UpdateCardDisplay()
    {
        // Aktualisiere die Textfelder mit den Werten der Card
        if (card != null)
        {
            goldText.text = card.gold.ToString();
            EXPText.text = card.exp.ToString();
            Holztext.text = card.holz.ToString();
            Steintext.text = card.stein.ToString();
        }
        else
        {
            UnityEngine.Debug.LogError("No card assigned!");
        }
    }
}
