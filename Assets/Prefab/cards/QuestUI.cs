using UnityEngine;
using UnityEngine.UI;
using TMPro;
using cardspace;

public class QuestUI : MonoBehaviour
{
    public TextMeshProUGUI questDescription;
    public Button completeButton;

    private Card card;
    private CardManager cardManager;
    private bool isQuestCompleted;

    public void Setup(Card card, CardManager cardManager, bool isQuestCompleted)
    {
        this.card = card;
        this.cardManager = cardManager;
        this.isQuestCompleted = isQuestCompleted;

        questDescription.text = $"Collect {card.holz} wood and {card.stein} stone to get {card.gold} gold and {card.exp} exp.";

        completeButton.interactable = !isQuestCompleted; // Disable button if quest is already completed

        completeButton.onClick.RemoveAllListeners(); // Remove existing listeners to prevent duplicates
        completeButton.onClick.AddListener(OnCompleteButtonClicked);
    }

    void OnCompleteButtonClicked()
    {
        if (!isQuestCompleted)
        {
            cardManager.CompleteQuest(card); // Pass the card to CompleteQuest method
        }
        else
        {
            UnityEngine.Debug.LogWarning("Quest already completed.");
        }
    }
}
