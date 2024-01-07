using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceManager : MonoBehaviour
{
    [Header("Experience")]
    [SerializeField] AnimationCurve experienceCurve;

    [SerializeField]
    private IntSO currentLevelSO;   // Definiert das jetztige XP-Level

    [SerializeField]
    private IntSO totalExperienceSO;    // Definiert die insgesamten XP

    [SerializeField]
    private IntSO previousLevelsExperienceSO;   // Definiert die XP, die für das vorherige Level benötigt werden

    [SerializeField]
    private IntSO nextLevelsExperienceSO;   // Definiert die XP, die für das nächste Level benötigt werden

    [Header("Interface")]
    [SerializeField] TextMeshProUGUI levelText;     // Definiert das es ein Textfeld geben muss 
    [SerializeField] TextMeshProUGUI experienceText;    // Definiert das es ein Textfeld geben muss 
    [SerializeField] Image experienceFill;  // Definiert das es ein Image geben muss 



    void Start()
    {
        UpdateLevel();  // Aktualisiert das Level

        // Abonniert die Ereignisse für den Kauf von Gebäuden und Steinbrüchen

        GameManager.OnFunctionExecuted += BuildingBought;
        StoneManager.OnFunctionExecuted += QuarryBought;
    }

    private void BuildingBought() // Methode, die aufgerufen wird, wenn ein Gebäude gekauft wird
    {
        AddExperience(100); //Vielleicht noch wird mehr desto mehr Gebäude
    }

    private void QuarryBought() // Methode, die aufgerufen wird, wenn ein Steinbruch gekauft wird
    {
        AddExperience(500);
    }

    private void OnDestroy() //  Methode, welche aufgerufe wird, wenn das Objekt zerstört wird.
    {
        // Wichtig! Meldet sich von Ereignissen ab, um Speicherlecks zu vermeiden
        GameManager.OnFunctionExecuted -= BuildingBought;
        StoneManager.OnFunctionExecuted -= QuarryBought;
    }

    void Update()
    {

    }

    public void AddExperience(int amount) // Methode zum Hinzufügen von Erfahrungspunkten und Überprüfen auf Levelaufstieg
    {
        totalExperienceSO.Value += amount;  // Fügt die Erfahrungspunkte hinzu
        CheckForLevelUp();  // Überprüft, ob ein Levelaufstieg erreicht wurde
        UpdateInterface();  // Aktualisiert die Benutzeroberfläche
    }

    void CheckForLevelUp()  // Überprüft, ob ein Levelaufstieg erreicht wurde
    {
        
        while (totalExperienceSO.Value >= nextLevelsExperienceSO.Value) // Solange die gesamten Erfahrungspunkte das nächste Level erreichen oder überschreiten
        {
            currentLevelSO.Value++; // Erhöhe das aktuelle Level
            UpdateLevel();  // Aktualisiere das Level

            // Vielleicht Level-Up sound noch
        }
    }

    // Aktualisiert das Level und zugehörige Erfahrungspunkte.
    void UpdateLevel()
    {
        previousLevelsExperienceSO.Value = (int)experienceCurve.Evaluate(currentLevelSO.Value); // Setzt die Erfahrungspunkte für vorheriges und nächstes Level
        nextLevelsExperienceSO.Value = (int)experienceCurve.Evaluate(currentLevelSO.Value + 1);
        UpdateInterface();  // Aktualisiert die Benutzeroberfläche
    }

    // Aktualisiere die Benutzeroberfläche mit aktuellen Werten
    void UpdateInterface()
    {
        // Berechne den Start- und Endwert für den Erfahrungsbalken
        int start = totalExperienceSO.Value - previousLevelsExperienceSO.Value;
        int end = nextLevelsExperienceSO.Value - previousLevelsExperienceSO.Value;

        // Aktualisiere die Textanzeigen auf der Benutzeroberfläche
        levelText.text = currentLevelSO.Value.ToString();
        experienceText.text = start + " exp / " + end + " exp";
        experienceFill.fillAmount = (float)start / (float)end;
    }
}