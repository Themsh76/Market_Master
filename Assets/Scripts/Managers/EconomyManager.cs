using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyManager : MonoBehaviour
{

    public int gold;    // Variable f�r den Goldwert
    public Text goldDisplay;    // Variable f�r die Anzeige des Goldwerts

    public int holz;    // Variable f�r den Holzwert
    public Text holzDisplay;    //Variable f�r die Anzeige des Holzwerts

    private int multipilikator = 1; // Wie viel ein Holzst�ck wert ist



    void Start()
    {
           holz = PlayerPrefs.GetInt("holzwert");   //Ausklammern falls man den Spielstand zur�cksetzen will
           gold = PlayerPrefs.GetInt("goldwert");

       // PlayerPrefs.GetInt("numberBuildings");
       
    }

    
    void Update()
    {
        goldDisplay.text = gold.ToString(); //Updated die Anzeige jede ms 
        holzDisplay.text = holz.ToString(); //Updated die Anzeige jede ms 

        PlayerPrefs.SetInt("holzwert", holz);   // Speichert den Holzwert global und f�r immer
        PlayerPrefs.SetInt("goldwert", gold);   // Speichert den Goldwert global und f�r immer
    }

    public void Sell()      // Methode, die das Holz f�r Gold verkauft
    {
        gold += holz*multipilikator;
        holz = 0;    
    } 
}
