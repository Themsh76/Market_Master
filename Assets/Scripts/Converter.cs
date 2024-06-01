using UnityEngine;
using UnityEngine.UI;
using TMPro;
using cardspace;
using System.Diagnostics;

public class Converter : MonoBehaviour
{
    public Text GoldDisplay; // Anzeige des Goldwerts
    public GameObject questUI; // Die UI für die Quest
    public GameObject questDoneUI; // Die UI für "Quest erledigt"

    [SerializeField] private IntSO GoldSO; // Scriptable Object für den Goldwert
    [SerializeField] private IntSO WoodAmount; // Scriptable Object für den Holzbestand
    [SerializeField] private IntSO StoneAmount; // Scriptable Object für den Steinbestand
    [SerializeField] private IntSO ExpAmount; // Scriptable Object für die Erfahrungspunkte
    [SerializeField] private Card conversionCard; // Card Scriptable Object, das die Konvertierungswerte enthält

    private bool isQuestCompleted = false; // Boolean zur Überprüfung, ob die Quest abgeschlossen wurde
    private ExperienceManager experienceManager; // Referenz auf den ExperienceManager

    void Start()
    {
        UpdateDisplays();
        experienceManager = FindObjectOfType<ExperienceManager>(); // Finde den ExperienceManager im Spiel
    }

    void UpdateDisplays()
    {
        GoldDisplay.text = GoldSO.Value.ToString();
    }

    public void ConvertResourcesToGoldAndEXP()
    {
        if (isQuestCompleted)
        {
            UnityEngine.Debug.Log("Quest already completed.");
            return;
        }

        if (WoodAmount.Value >= conversionCard.holz && StoneAmount.Value >= conversionCard.stein)
        {
            WoodAmount.Value -= conversionCard.holz;
            StoneAmount.Value -= conversionCard.stein;
            GoldSO.Value += conversionCard.gold;
            ExpAmount.Value += conversionCard.exp;

            isQuestCompleted = true; // Markiere die Quest als abgeschlossen
            UpdateDisplays(); // Aktualisiert die Anzeige

            // Entferne die UI-Elemente
            Destroy(questUI);
            questDoneUI.SetActive(true);

            // Erfahrungspunkte und Level aktualisieren
            experienceManager.AddExperience(conversionCard.exp);
        }
        else
        {
            UnityEngine.Debug.Log("Not enough resources for conversion.");
        }

    }
}
