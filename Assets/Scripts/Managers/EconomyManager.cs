using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyManager : MonoBehaviour
{

    public Text goldDisplay;    // Variable für die Anzeige des Goldwerts
  
    public Text holzDisplay;    //Variable für die Anzeige des Holzwerts

    [SerializeField]
    private IntSO PriceWoodMultiplicatorSO; // Wie viel ein Holzstück wert ist

    public int zähler;  // Variable die ms zählt

    [SerializeField]
    private IntSO BuildingsSO;

    [SerializeField]
    private IntSO GoldSO; // Scriptable Object für den Goldwert

    [SerializeField]
    private IntSO WoodSO; // Scriptable Object für den Holzwert

    [SerializeField]
    private StringSO PlacedBuildingsSO; // Scriptable Object für die Position der platzierten Gebäude

    [SerializeField]
    private IntSO WoodMsSO; // Nach wie vielen MS ein Holz erwirtschaftet wird

    [SerializeField]
    private IntSO WoodMultiplicatorSO; // Erwirtschafte Hölzer pro Zeiteinheit

    void Start()
    {
        
    }

    
    void Update()
    {
        goldDisplay.text = GoldSO.Value.ToString(); //Updated die Anzeige jede ms 
        holzDisplay.text = WoodSO.Value.ToString(); //Updated die Anzeige jede ms 


        if (BuildingsSO.Value > 0)      // Schaut ob schon etwas platziert wurde
        {

            if (zähler == WoodMsSO.Value)      // Wenn eine Sekunde vergangen ist geht es in die Methode
            {
                WoodSO.Value += WoodMultiplicatorSO.Value * BuildingsSO.Value; //numberOfBuildings;     // Erhöt den Holzwert
                zähler = 0;     // Setzt den Zähler auf 0
            }
            zähler++;
        }


    }

    public void Sell()      // Methode, die das Holz für Gold verkauft
    {
        GoldSO.Value += WoodSO.Value * PriceWoodMultiplicatorSO.Value;
        WoodSO.Value = 0;    
    } 

    
}
