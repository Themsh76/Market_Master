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
    private IntSO previousLevelsExperienceSO;   // Definiert die XP, die f�r das vorherige Level ben�tigt werden

    [SerializeField]
    private IntSO nextLevelsExperienceSO;   // Definiert die XP, die f�r das n�chste Level ben�tigt werden

    [Header("Interface")]
    [SerializeField] TextMeshProUGUI levelText;     // Definiert das es ein Textfeld geben muss 
    [SerializeField] TextMeshProUGUI experienceText;    // Definiert das es ein Textfeld geben muss 
    [SerializeField] Image experienceFill;  // Definiert das es ein Image geben muss 



    void Start()
    {
        UpdateLevel();  // Aktualisiert das Level

        // Abonniert die Ereignisse f�r den Kauf von Geb�uden und Steinbr�chen

        GameManager.OnFunctionExecuted += BuildingBought;
        StoneManager.OnFunctionExecuted += QuarryBought;
    }

    private void BuildingBought() // Methode, die aufgerufen wird, wenn ein Geb�ude gekauft wird
    {
        AddExperience(100); //Vielleicht noch wird mehr desto mehr Geb�ude
    }

    private void QuarryBought() // Methode, die aufgerufen wird, wenn ein Steinbruch gekauft wird
    {
        AddExperience(500);
    }

    private void OnDestroy() //  Methode, welche aufgerufe wird, wenn das Objekt zerst�rt wird.
    {
        // Wichtig! Meldet sich von Ereignissen ab, um Speicherlecks zu vermeiden
        GameManager.OnFunctionExecuted -= BuildingBought;
        StoneManager.OnFunctionExecuted -= QuarryBought;
    }

    void Update()
    {

    }

    public void AddExperience(int amount) // Methode zum Hinzuf�gen von Erfahrungspunkten und �berpr�fen auf Levelaufstieg
    {
        totalExperienceSO.Value += amount;  // F�gt die Erfahrungspunkte hinzu
        CheckForLevelUp();  // �berpr�ft, ob ein Levelaufstieg erreicht wurde
        UpdateInterface();  // Aktualisiert die Benutzeroberfl�che
    }

    void CheckForLevelUp()  // �berpr�ft, ob ein Levelaufstieg erreicht wurde
    {
        
        while (totalExperienceSO.Value >= nextLevelsExperienceSO.Value) // Solange die gesamten Erfahrungspunkte das n�chste Level erreichen oder �berschreiten
        {
            currentLevelSO.Value++; // Erh�he das aktuelle Level
            UpdateLevel();  // Aktualisiere das Level

            // Vielleicht Level-Up sound noch
        }
    }

    // Aktualisiert das Level und zugeh�rige Erfahrungspunkte.
    void UpdateLevel()
    {
        previousLevelsExperienceSO.Value = (int)experienceCurve.Evaluate(currentLevelSO.Value); // Setzt die Erfahrungspunkte f�r vorheriges und n�chstes Level
        nextLevelsExperienceSO.Value = (int)experienceCurve.Evaluate(currentLevelSO.Value + 1);
        UpdateInterface();  // Aktualisiert die Benutzeroberfl�che
    }

    // Aktualisiere die Benutzeroberfl�che mit aktuellen Werten
    void UpdateInterface()
    {
        // Berechne den Start- und Endwert f�r den Erfahrungsbalken
        int start = totalExperienceSO.Value - previousLevelsExperienceSO.Value;
        int end = nextLevelsExperienceSO.Value - previousLevelsExperienceSO.Value;

        // Aktualisiere die Textanzeigen auf der Benutzeroberfl�che
        levelText.text = currentLevelSO.Value.ToString();
        experienceText.text = start + " exp / " + end + " exp";
        experienceFill.fillAmount = (float)start / (float)end;
    }
}