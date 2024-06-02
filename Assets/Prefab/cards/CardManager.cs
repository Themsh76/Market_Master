using System.Collections.Generic;
using UnityEngine;
using cardspace;

public class CardManager : MonoBehaviour
{
    public List<Card> cards; // List of all card scriptable objects
    public List<GameObject> questUIPrefabs; // List of UI prefabs for each card

    private Dictionary<Card, bool> questCompletionStatus; // Track completion status for each card
    private Dictionary<Card, GameObject> questUIInstances; // Track instantiated quest UIs
    private Card currentCard;

    void Start()
    {
        questCompletionStatus = new Dictionary<Card, bool>();
        questUIInstances = new Dictionary<Card, GameObject>();

        foreach (Card card in cards)
        {
            questCompletionStatus.Add(card, false);
            questUIInstances.Add(card, null);
        }

        // Load the first card
        LoadCard(cards[0]);
    }

    void LoadCard(Card card)
    {
        if (questUIInstances.ContainsKey(card) && questUIInstances[card] != null)
        {
            Destroy(questUIInstances[card]); // Remove the previous quest UI
        }

        GameObject questUIPrefab = questUIPrefabs[cards.IndexOf(card)];
        GameObject questUIInstance = Instantiate(questUIPrefab, transform);
        questUIInstances[card] = questUIInstance;
        currentCard = card;

        // Assuming each quest UI has a script that handles its own logic
        QuestUI questUI = questUIInstance.GetComponent<QuestUI>();
        if (questUI != null)
        {
            questUI.Setup(card, this, questCompletionStatus[card]); // Pass the card and completion status
        }
    }

    public void CompleteQuest(Card card)
    {
        questCompletionStatus[card] = true; // Mark the current quest as completed

        // Find the next incomplete quest
        foreach (Card c in cards)
        {
            if (!questCompletionStatus[c])
            {
                LoadCard(c);
                return;
            }
        }

        // If all quests are completed
        UnityEngine.Debug.Log("All quests completed.");
    }
}
