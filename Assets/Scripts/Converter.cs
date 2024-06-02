using UnityEngine;
using UnityEngine.UI;
using TMPro;
using cardspace;
using System.Collections.Generic;

public class Converter : MonoBehaviour
{
    public List<Card> cards; // List of all card scriptable objects
    public List<GameObject> questUIPrefabs; // List of UI prefabs for each card
    public List<GameObject> questUIDonePrefabs; // List of UI prefabs for completed quests

    public Text GoldDisplay; // Anzeige des Goldwerts

    [SerializeField] private IntSO GoldSO; // Scriptable Object für den Goldwert
    [SerializeField] private IntSO WoodAmount; // Scriptable Object für den Holzbestand
    [SerializeField] private IntSO StoneAmount; // Scriptable Object für den Steinbestand
    [SerializeField] private IntSO ExpAmount; // Scriptable Object für die Erfahrungspunkte
    [SerializeField] private ExperienceManager experienceManager; // Referenz auf den ExperienceManager

    private HashSet<Card> completedCards = new HashSet<Card>(); // HashSet to store completed cards
    private Dictionary<Card, GameObject> cardToUIPrefabMap = new Dictionary<Card, GameObject>(); // Map cards to their UI prefabs
    private Dictionary<Card, GameObject> cardToUIDonePrefabMap = new Dictionary<Card, GameObject>(); // Map cards to their completed UI prefabs

    void Start()
    {
        // Assuming cards and questUIPrefabs have the same count and correspond to each other
        for (int i = 0; i < cards.Count; i++)
        {
            cardToUIPrefabMap[cards[i]] = questUIPrefabs[i];
            cardToUIDonePrefabMap[cards[i]] = questUIDonePrefabs[i];
        }

       
       LoadCompletedQuests();
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

            // Deactivate the UI prefab for the completed card
            if (cardToUIPrefabMap.TryGetValue(card, out GameObject uiPrefab))
            {
                if (uiPrefab != null) // Check if the UI prefab exists
                {
                    uiPrefab.SetActive(false);
                }
            }

            // Enable the completed UI prefab
            if (cardToUIDonePrefabMap.TryGetValue(card, out GameObject uiDonePrefab))
            {
                if (uiDonePrefab != null) // Check if the completed UI prefab exists
                {
                    uiDonePrefab.SetActive(true);
                }
            }

            SaveCompletedQuests();

            // Optional: Andere Systeme benachrichtigen oder Events auslösen
            NotifyQuestCompletion();
        }
        else
        {
            UnityEngine.Debug.Log("Not enough resources for conversion.");
        }
    }

    void ResetCompletedQuests()
    {
        PlayerPrefs.DeleteKey("CompletedQuests");
        PlayerPrefs.Save();
    }


    void SaveCompletedQuests()
    {
        List<string> completedCardNames = new List<string>();
        foreach (Card card in completedCards)
        {
            completedCardNames.Add(card.name);
        }
        string completedCardsString = string.Join(",", completedCardNames);
        PlayerPrefs.SetString("CompletedQuests", completedCardsString);
        PlayerPrefs.Save();
    }

    void LoadCompletedQuests()
    {
        string completedCardsString = PlayerPrefs.GetString("CompletedQuests", "");
        if (!string.IsNullOrEmpty(completedCardsString))
        {
            string[] completedCardNames = completedCardsString.Split(',');
            foreach (string cardName in completedCardNames)
            {
                Card card = cards.Find(c => c.name == cardName);
                if (card != null)
                {
                    completedCards.Add(card);
                    // Destroy the UI prefab for the completed card
                    if (cardToUIPrefabMap.TryGetValue(card, out GameObject uiPrefab))
                    {
                        Destroy(uiPrefab);
                    }
                    // Enable the completed UI prefab
                    if (cardToUIDonePrefabMap.TryGetValue(card, out GameObject uiDonePrefab))
                    {
                        uiDonePrefab.SetActive(true);
                    }
                }
            }
        }
    }
    
    void NotifyQuestCompletion()
    {
        // Optional: Andere Systeme benachrichtigen oder Events auslösen
    }


    public void ResetQuests()
    {
        // Clear the completed quests
        completedCards.Clear();

        // Recreate original quest UI prefabs
        foreach (var pair in cardToUIPrefabMap)
        {
            if (pair.Value == null) // If the UI prefab was destroyed, recreate it
            {
                GameObject originalPrefab = questUIPrefabs[cards.IndexOf(pair.Key)];
                if (originalPrefab != null) // Check if the original prefab exists
                {
                    GameObject newUIPrefab = Instantiate(originalPrefab, transform);
                    cardToUIPrefabMap[pair.Key] = newUIPrefab;
                }
            }
            else
            {
                pair.Value.SetActive(true);
            }
        }

        // Disable completed quest UI prefabs
        foreach (var pair in cardToUIDonePrefabMap)
        {
            pair.Value.SetActive(false);
        }

        // Reset saved completed quests
        ResetCompletedQuests();
    }


}
