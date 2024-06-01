using UnityEngine;
using UnityEngine.UI;
using TMPro;
using cardspace;
using System.Collections.Generic;


public class Converter : MonoBehaviour
{
    public Text GoldDisplay; // Anzeige des Goldwerts

    [SerializeField] private IntSO GoldSO; // Scriptable Object für den Goldwert
    [SerializeField] private IntSO WoodAmount; // Scriptable Object für den Holzbestand
    [SerializeField] private IntSO StoneAmount; // Scriptable Object für den Steinbestand
    [SerializeField] private IntSO ExpAmount; // Scriptable Object für die Erfahrungspunkte
    [SerializeField] private ExperienceManager experienceManager; // Referenz auf den ExperienceManager

    private HashSet<Card> completedCards = new HashSet<Card>(); // HashSet to store completed cards

    void Start()
    {
        UpdateDisplays();
    }

    void UpdateDisplays()
    {
        GoldDisplay.text = GoldSO.Value.ToString();
    }

    public void ConvertResourcesToGoldAndEXP(Card card)
    {
        if (completedCards.Contains(card))
        {
            UnityEngine.Debug.Log("Quest for this card already completed.");
            return;
        }

        if (WoodAmount.Value >= card.holz && StoneAmount.Value >= card.stein)
        {
            WoodAmount.Value -= card.holz;
            StoneAmount.Value -= card.stein;
            GoldSO.Value += card.gold;
            ExpAmount.Value += card.exp;

            completedCards.Add(card); // Mark the card as completed
            UpdateDisplays(); // Aktualisiert die Anzeige

            // Aktualisiere das Level
            if (experienceManager != null)
            {
                experienceManager.AddExperience(card.exp);
            }

            // Optional: Andere Systeme benachrichtigen oder Events auslösen
            NotifyQuestCompletion();
        }
        else
        {
            UnityEngine.Debug.Log("Not enough resources for conversion.");
        }
    }

    void NotifyQuestCompletion()
    {
        // Optional: Andere Systeme benachrichtigen oder Events auslösen
    }
}
