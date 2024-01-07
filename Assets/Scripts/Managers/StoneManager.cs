using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
//using UnityEditor.U2D.Aseprite;
using UnityEngine;
//using UnityEngine.Experimental.Rendering;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class StoneManager : MonoBehaviour
{
    public Text goldDisplay;    // Variable für die Anzeige des Goldwerts
    public Text holzDisplay;    // Variable für die Anzeige des Holzwerts
    public Text steinDisplay;   // Variable für die Anzeige des Steinwerts
    public Text buildingCost;   // Instanz zur Anzeige von den Kosten eines Gebäudes

    private Steinbruch quarryToPlace;   // Variable für das Gebäude was plaziert werden soll
    private Steinbruch resetSteinbruch;
    public GameObject Grid;     // Object welches das Feld widerspiegelt
    public CustomCursor customCursor;   // Leitet eine Instanz von Customcursor ab

    public Tile[] tiles;    // Array von Feldern

    private int WoodCount;      // Variable die ms zählt
    private int StoneCount;     // Variable die ms zählt

    [SerializeField]
    private IntSO WoodMsSO; // Nach wie vielen MS ein Holz erwirtschaftet wird

    [SerializeField]
    private IntSO WoodMultiplicatorSO; // Erwirtschafte Hölzer pro Zeiteinheit   

    [SerializeField]
    private StringSO WoodPlacedBuildingsSO; // Scriptable Object für die Position der platzierten Gebäude

    public ToogleActivationOnSceneChange toogle;    // Leitet eine Instanz von ToogleActivationOnSceneChange ab

    [SerializeField]
    private IntSO WoodBuildingsSO; // Wie viele Gebäude platziert wurden

    [SerializeField]
    private IntSO GoldSO; // Scriptable Object für den Goldwert

    [SerializeField]
    private IntSO WoodSO; // Scriptable Object für den Holzwert

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

    [SerializeField]
    private IntSO GlobalMultiplicatorAmount;  // Scriptable Object für den globalen Multiplicator

    public delegate void BuyQuarryExecutedDelegate();   // Definition eines Delegaten  
    public static event BuyQuarryExecutedDelegate OnFunctionExecuted;   // Deklariert ein Ereignis mit dem oben definierten Delegaten.


    private void Start()
    {
        toogle.OnSceneLoaded();   // Aktiviert den Toogle

    }



    private void Update()
    {
        goldDisplay.text = GoldSO.Value.ToString(); //Updated die Anzeige jede ms 
        holzDisplay.text = WoodSO.Value.ToString(); //Updated die Anzeige jede ms 
        steinDisplay.text = StoneSO.Value.ToString();   //Updated die Anzeige jede ms 
        buildingCost.text = (500 * (1 + StoneBuildingsSO.Value)).ToString(); // Updated die Anzeige jede ms


        if (Input.GetMouseButtonDown(0) && quarryToPlace != null)     //Schaut ob die linke Maustaste gedrückt ist und ob ein Haus gerade platziert werden soll
        {
            Tile nearestTile = null;    // Variable die angibt welches Feld am nächsten ist
            float shortestDistance = float.MaxValue;    // Variable, welche schaut welches Feld am nächsten ist

            foreach (Tile tile in tiles)    // Schleife die schaut welches Feld am nächsten ist
            {
                float distance = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)); // Schaut wo die Maus ist und welche Tile wo ist
                if (distance < shortestDistance && distance < 50)    // Schaut ob das nächste Feld in der Schleife näher ist als das zuvor
                {
                    shortestDistance = distance;    // Setzt die Distanz zum jetzigen Feld als kürzeste Distanz
                    nearestTile = tile;     // Setzt die nahste Feld als nahstes Feld
                }
            }





            if (shortestDistance < 50)    // Schaut, ob das nahste Feld beim Klick nicht befüllt ist
            {

                if (nearestTile.isOccupied == false)
                {

                    int pos = Array.IndexOf(tiles, nearestTile);    // Holt sich die Position von der am nächsten Tile
                    StonePlacedBuildingsSO.Value += pos;   // Fügt die Position dem String hinzu

                    Instantiate(quarryToPlace, nearestTile.transform.position, Quaternion.identity);  // Setzt das Building ohne Drehung in das Feld                 
                    quarryToPlace = null;     // Entfernt das Building am Cursor 
                    nearestTile.isOccupied = true;      // Setzt das Feld auf dem das Building plaziert auf befüllt
                    Grid.SetActive(false);      // Deaktiviert das Grid
                    customCursor.gameObject.SetActive(false);   // Deaktiviert den Custom Cursor
                    Cursor.visible = true;  // Aktiviert den normalen Cursor 

                    StoneBuildingsSO.Value++;



                }
            }
        }


        if (WoodBuildingsSO.Value > 0)      // Schaut ob schon etwas platziert wurde
        {

            if (WoodCount == WoodMsSO.Value)      // Wenn die Zeiteinheit vergangen ist geht es in die Methode
            {
                WoodSO.Value += WoodMultiplicatorSO.Value * WoodBuildingsSO.Value * GlobalMultiplicatorAmount.Value; // Erhöt den Holzwert
                WoodCount = 0;     // Setzt den Zähler auf 0
            }
            WoodCount++;
        }

        if (StoneBuildingsSO.Value > 0)      // Schaut ob schon etwas platziert wurde
        {

            if (StoneCount == StoneMsSO.Value)      // Wenn die Zeiteinheit vergangen ist geht es in die Methode
            {
                StoneSO.Value += StoneMultiplicatorSO.Value * StoneBuildingsSO.Value * GlobalMultiplicatorAmount.Value; // Erhöt den Holzwert
                StoneCount = 0;     // Setzt den Zähler auf 0
            }
            StoneCount++;
        }

    }



    public void LoadQuarryPositions(Steinbruch steinbruch)    // Lädt die Buildings und platziert sie auf ihren ursprünglichen Platz
    {

        resetSteinbruch = steinbruch;     // Legt fest, dass ein Building plaziert werden soll

        foreach (char c in StonePlacedBuildingsSO.Value)      // Schleife welche schaut welche Buildings platziert sind
        {

            int i = c - '0';    // Konvertiert char zu int
            Instantiate(resetSteinbruch, tiles[i].transform.position, Quaternion.identity);   // Platziert buildings auf ihrer vorigen Position.
            tiles[i].isOccupied = true;     // Setzt die Tiles, auf die etwas platziert wurde auf besetzt

        }
    }




    public void BuyQuarry(Steinbruch steinbruch)  // Funktion, die das platzieren eines Gebäudes möglich macht
    {
        if (StoneBuildingsSO.Value < tiles.Length)
        {
            if (GoldSO.Value >= steinbruch.cost)      // Schaut ob man genug Gold hat
            {
                Grid.SetActive(true);       // Aktiviert das Grid
                GoldSO.Value -= steinbruch.cost;      // Zieht die Kosten vom Goldwert ab
                quarryToPlace = steinbruch;     // Legt fest, dass ein Building plaziert werden soll
                customCursor.gameObject.SetActive(true);  // Aktiviert Customcursor
                customCursor.GetComponent<SpriteRenderer>().sprite = steinbruch.GetComponent<SpriteRenderer>().sprite;    // Gibt den Custom Cursor ein Building was mit dem Cursor mitgeht
                Cursor.visible = false; // Deaktiviert den normalen Cursor

                OnFunctionExecuted?.Invoke();   // Führt das Ereignis in Verbindung mit dem Delegate aus 

            }
        }
    }
}
