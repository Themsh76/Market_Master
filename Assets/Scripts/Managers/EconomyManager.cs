using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyManager : MonoBehaviour
{

    public int gold;    // Variable für den Goldwert
    public Text goldDisplay;    // Variable für die Anzeige des Goldwerts

    public int holz;    // Variable für den Holzwert
    public Text holzDisplay;    //Variable für die Anzeige des Holzwerts

    private int multipilikator = 1; // Wie viel ein Holzstück wert ist



    void Start()
    {
           holz = PlayerPrefs.GetInt("holzwert");   //Ausklammern falls man den Spielstand zurücksetzen will
           gold = PlayerPrefs.GetInt("goldwert");

       // PlayerPrefs.GetInt("numberBuildings");
       
    }

    
    void Update()
    {
        goldDisplay.text = gold.ToString(); //Updated die Anzeige jede ms 
        holzDisplay.text = holz.ToString(); //Updated die Anzeige jede ms 

        PlayerPrefs.SetInt("holzwert", holz);   // Speichert den Holzwert global und für immer
        PlayerPrefs.SetInt("goldwert", gold);   // Speichert den Goldwert global und für immer
    }

    public void Sell()      // Methode, die das Holz für Gold verkauft
    {
        gold += holz*multipilikator;
        holz = 0;    
    } 
}
