using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameValues : MonoBehaviour
{
    [SerializeField]
    private IntSO PriceWoodMultiplicatorSO; // Wie viel ein Holzstück wert ist

    [SerializeField]
    private IntSO WoodBuildingsSO;  // Wie viele Gebäude platziert wurden

    [SerializeField]
    private IntSO GoldSO; // Scriptable Object für den Goldwert

    [SerializeField]
    private IntSO WoodSO; // Scriptable Object für den Holzwert

    [SerializeField]
    private StringSO WoodPlacedBuildingsSO; // Scriptable Object für die Position der platzierten Gebäude

    [SerializeField]
    private IntSO WoodMultiplicatorSO; // Erwirtschafte Hölzer pro Zeiteinheit

    [SerializeField]
    private IntSO StoneSO;  // Scriptable Object für den Steinwert

    [SerializeField]
    private IntSO StoneMultiplicatorSO;     // Erwirtschafte Steine pro Zeiteinheit

    [SerializeField]
    private IntSO PriceStoneMultiplicatorSO;    // Wie viel ein Stein wert ist

    [SerializeField]
    private IntSO StoneBuildingsSO; // Wie viele Gebäude platziert wurden

    [SerializeField]
    private StringSO StonePlacedBuildingsSO; // Scriptable Object für die Position der platzierten Gebäude

    public int PriceWoodMultiplicator;
    public int WoodMultiplicator;
    public string WoodPlacedBuildings;
    public int WoodBuildings;
    public int Wood;
    public int Gold;
    public int Stone;
    public int StoneBuildings;
    public int StoneMultiplicator;
    public string StonePlacedBuildings;
    public int PriceStoneMultiplicator;



    public GameValues()
    {
        PriceWoodMultiplicator = PriceWoodMultiplicatorSO.Value;
        WoodMultiplicator = WoodMultiplicatorSO.Value;
        WoodPlacedBuildings = WoodPlacedBuildingsSO.Value;
        WoodBuildings = WoodBuildingsSO.Value;
        Wood = WoodSO.Value;
        Gold = GoldSO.Value;
        Stone = StoneSO.Value;
        StoneBuildings = StoneBuildingsSO.Value;
        StoneMultiplicator = StoneMultiplicatorSO.Value;
        StonePlacedBuildings = StonePlacedBuildingsSO.Value;
        PriceStoneMultiplicator = PriceStoneMultiplicatorSO.Value;
    }


}
