using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startwerte : MonoBehaviour
{
    private int holz = 50;
    private int gold = 50;

    public Startwerte startwert;

    [SerializeField]
    private IntSO BuildingsSO; // Wie viele Gebäude platziert wurden

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

    [SerializeField]
    private IntSO PriceWoodMultiplicatorSO; // Wie viel ein Holzstück wert ist


    public void Startwertefestlegen()
    {
        WoodSO.Value = holz;   // Legt den Startwert der Hölzer auf Holz
        GoldSO.Value = gold;   // Legt den Startwert des Golds auf Gold
        BuildingsSO.Value = 0;  // Setzt die Anzahl der Gebäude auf 0
        PlacedBuildingsSO.Value = "";   // Setzt die Positionen der Gebäude auf empty
        WoodMsSO.Value = 1000;  // Legt fest nach wie vilen ms Holz erwirtschaftet werden soll
        WoodMultiplicatorSO.Value = 1;  // Legt fest wie viel Holz pro Zyklus erwirtschaftet werden soll
        PriceWoodMultiplicatorSO.Value = 1; // Legt fest wie viel ein Holzstück wert ist
    }
}
