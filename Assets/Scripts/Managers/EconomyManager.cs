using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyManager : MonoBehaviour
{

    public Text goldDisplay;    // Variable f�r die Anzeige des Goldwerts
  
    public Text holzDisplay;    //Variable f�r die Anzeige des Holzwerts

    [SerializeField]
    private IntSO PriceWoodMultiplicatorSO; // Wie viel ein Holzst�ck wert ist

    public int z�hler;  // Variable die ms z�hlt

    [SerializeField]
    private IntSO BuildingsSO;

    [SerializeField]
    private IntSO GoldSO; // Scriptable Object f�r den Goldwert

    [SerializeField]
    private IntSO WoodSO; // Scriptable Object f�r den Holzwert

    [SerializeField]
    private StringSO PlacedBuildingsSO; // Scriptable Object f�r die Position der platzierten Geb�ude

    [SerializeField]
    private IntSO WoodMsSO; // Nach wie vielen MS ein Holz erwirtschaftet wird

    [SerializeField]
    private IntSO WoodMultiplicatorSO; // Erwirtschafte H�lzer pro Zeiteinheit

    void Start()
    {
        
    }

    
    void Update()
    {
        goldDisplay.text = GoldSO.Value.ToString(); //Updated die Anzeige jede ms 
        holzDisplay.text = WoodSO.Value.ToString(); //Updated die Anzeige jede ms 


        if (BuildingsSO.Value > 0)      // Schaut ob schon etwas platziert wurde
        {

            if (z�hler == WoodMsSO.Value)      // Wenn eine Sekunde vergangen ist geht es in die Methode
            {
                WoodSO.Value += WoodMultiplicatorSO.Value * BuildingsSO.Value; //numberOfBuildings;     // Erh�t den Holzwert
                z�hler = 0;     // Setzt den Z�hler auf 0
            }
            z�hler++;
        }


    }

    public void Sell()      // Methode, die das Holz f�r Gold verkauft
    {
        GoldSO.Value += WoodSO.Value * PriceWoodMultiplicatorSO.Value;
        WoodSO.Value = 0;    
    } 

    
}
