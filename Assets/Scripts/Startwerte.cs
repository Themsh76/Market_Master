using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startwerte : MonoBehaviour
{

    public Startwerte startwert;

    [SerializeField]
    private IntSO WoodBuildingsSO; // Wie viele Gebäude platziert wurden

    [SerializeField]
    private StringSO WoodPlacedBuildingsSO; // Scriptable Object für die Position der platzierten Gebäude

    [SerializeField]
    private IntSO GoldSO; // Scriptable Object für den Goldwert

    [SerializeField]
    private IntSO WoodSO; // Scriptable Object für den Holzwert

    [SerializeField]
    private IntSO WoodMsSO; // Nach wie vielen MS ein Holz erwirtschaftet wird

    [SerializeField]
    private IntSO WoodMultiplicatorSO; // Erwirtschafte Hölzer pro Zeiteinheit

    [SerializeField]
    private IntSO PriceWoodMultiplicatorSO; // Wie viel ein Holzstück wert ist

    [SerializeField]
    private IntSO StoneSO;  // Scriptable Object für den Steinwert

    [SerializeField]
    private IntSO StoneMultiplicatorSO;     // Erwirtschafte Steine pro Zeiteinheit

    [SerializeField]
    private IntSO StoneMsSO;    // Nach wie vielen MS ein Stein erwirtschaftet wird

    [SerializeField]
    private IntSO PriceStoneMultiplicatorSO;    // Wie viel ein Stein wert ist

    [SerializeField]
    private IntSO StoneBuildingsSO; // Wie viele Gebäude platziert wurden

    [SerializeField]
    private StringSO StonePlacedBuildingsSO; // Scriptable Object für die Position der platzierten Gebäude

    public void Startwertefestlegen()
    {
        WoodSO.Value = 50;   // Legt den Startwert der Hölzer fest
        GoldSO.Value = 50000;   // Legt den Startwert des Golds fest
        WoodBuildingsSO.Value = 0;  // Setzt die Anzahl der Gebäude auf 0
        WoodPlacedBuildingsSO.Value = "";   // Setzt die Positionen der Gebäude auf empty
        WoodMsSO.Value = 1000;  // Legt fest nach wie vilen ms Holz erwirtschaftet werden soll
        WoodMultiplicatorSO.Value = 1;  // Legt fest wie viel Holz pro Zyklus erwirtschaftet werden soll
        PriceWoodMultiplicatorSO.Value = 1; // Legt fest wie viel ein Holzstück wert ist
        StoneSO.Value = 0;  // Legt den Startwert der Steine fest
        StoneMsSO.Value = 10000;    // Legt fest nach wie vilen ms Stein erwirtschaftet werden soll
        StoneMultiplicatorSO.Value = 1; // Legt fest wie viel Stein pro Zyklus erwirtschaftet werden soll
        PriceStoneMultiplicatorSO.Value = 25;   // Legt fest wie viel ein Stein wert ist
        StoneBuildingsSO.Value = 0; // Setzt die Anzahl der Steinbrüche auf 0
        StonePlacedBuildingsSO.Value = "";  // Setzt die Positionen der Steinbrüche auf empty
    }
}
