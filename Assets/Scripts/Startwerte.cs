using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startwerte : MonoBehaviour
{
    private int holz = 50;
    private int gold = 50;

    public Startwerte startwert;

    [SerializeField]
    private IntSO BuildingsSO; // Wie viele Geb�ude platziert wurden

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

    [SerializeField]
    private IntSO PriceWoodMultiplicatorSO; // Wie viel ein Holzst�ck wert ist


    public void Startwertefestlegen()
    {
        WoodSO.Value = holz;   // Legt den Startwert der H�lzer auf Holz
        GoldSO.Value = gold;   // Legt den Startwert des Golds auf Gold
        BuildingsSO.Value = 0;  // Setzt die Anzahl der Geb�ude auf 0
        PlacedBuildingsSO.Value = "";   // Setzt die Positionen der Geb�ude auf empty
        WoodMsSO.Value = 1000;  // Legt fest nach wie vilen ms Holz erwirtschaftet werden soll
        WoodMultiplicatorSO.Value = 1;  // Legt fest wie viel Holz pro Zyklus erwirtschaftet werden soll
        PriceWoodMultiplicatorSO.Value = 1; // Legt fest wie viel ein Holzst�ck wert ist
    }
}
