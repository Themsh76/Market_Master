using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyManager : MonoBehaviour
{

    public Text goldDisplay;    // Variable f�r die Anzeige des Goldwerts
  
    public Text holzDisplay;    //Variable f�r die Anzeige des Holzwerts

    public Text steinDisplay;   // Variable f�r die Anzeige des Steinwerts

    private int WoodCount;      // Variable die ms z�hlt

    private int StoneCount;     // Variable die ms z�hlt

    [SerializeField]
    private IntSO PriceWoodMultiplicatorSO; // Wie viel ein Holzst�ck wert ist

    [SerializeField]
    private IntSO WoodBuildingsSO;  // Wie viele Geb�ude platziert wurden

    [SerializeField]
    private IntSO GoldSO; // Scriptable Object f�r den Goldwert

    [SerializeField]
    private IntSO WoodSO; // Scriptable Object f�r den Holzwert

    [SerializeField]
    private StringSO WoodPlacedBuildingsSO; // Scriptable Object f�r die Position der platzierten Geb�ude

    [SerializeField]
    private IntSO WoodMsSO; // Nach wie vielen MS ein Holz erwirtschaftet wird

    [SerializeField]
    private IntSO WoodMultiplicatorSO; // Erwirtschafte H�lzer pro Zeiteinheit

    [SerializeField]
    private IntSO StoneSO;  // Scriptable Object f�r den Steinwert

    [SerializeField]
    private IntSO StoneMultiplicatorSO;     // Erwirtschafte Steine pro Zeiteinheit

    [SerializeField]
    private IntSO StoneMsSO;    // Nach wie vielen MS ein Stein erwirtschaftet wird

    [SerializeField]
    private IntSO PriceStoneMultiplicatorSO;    // Wie viel ein Stein wert ist

    [SerializeField]
    private IntSO StoneBuildingsSO; // Wie viele Geb�ude platziert wurden

    [SerializeField]
    private StringSO StonePlacedBuildingsSO; // Scriptable Object f�r die Position der platzierten Geb�ude


    void Start()
    {
        
    }

    
    void Update()
    {
        goldDisplay.text = GoldSO.Value.ToString(); //Updated die Anzeige jede ms 
        holzDisplay.text = WoodSO.Value.ToString(); //Updated die Anzeige jede ms 
        steinDisplay.text = StoneSO.Value.ToString();   //Updated die Anzeige jede ms 


        if (WoodBuildingsSO.Value > 0)      // Schaut ob schon etwas platziert wurde
        {

            if (WoodCount == WoodMsSO.Value)      // Wenn die Zeiteinheit vergangen ist geht es in die Methode
            {
                WoodSO.Value += WoodMultiplicatorSO.Value * WoodBuildingsSO.Value; // Erh�t den Holzwert
                WoodCount = 0;     // Setzt den Z�hler auf 0
            }
            WoodCount++;
        }

        if (StoneBuildingsSO.Value > 0)      // Schaut ob schon etwas platziert wurde
        {

            if (StoneCount == StoneMsSO.Value)      // Wenn die Zeiteinheit vergangen ist geht es in die Methode
            {
                StoneSO.Value += StoneMultiplicatorSO.Value * StoneBuildingsSO.Value; // Erh�t den Holzwert
                StoneCount = 0;     // Setzt den Z�hler auf 0
            }
            StoneCount++;
        }


    }

    public void Sell()      // Methode, die das Holz f�r Gold verkauft
    {
        GoldSO.Value += WoodSO.Value * PriceWoodMultiplicatorSO.Value;
        GoldSO.Value += StoneSO.Value * PriceStoneMultiplicatorSO.Value;
        WoodSO.Value = 0;    
        StoneSO.Value = 0;
    } 

    
}
