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
    public Text goldDisplay;    // Variable f�r die Anzeige des Goldwerts
    public Text holzDisplay;    // Variable f�r die Anzeige des Holzwerts
    public Text steinDisplay;   // Variable f�r die Anzeige des Steinwerts
    public Text buildingCost;   // Instanz zur Anzeige von den Kosten eines Geb�udes

    private Steinbruch quarryToPlace;   // Variable f�r das Geb�ude was plaziert werden soll
    private Steinbruch resetSteinbruch;
    public GameObject Grid;     // Object welches das Feld widerspiegelt
    public CustomCursor customCursor;   // Leitet eine Instanz von Customcursor ab

    public Tile[] tiles;    // Array von Feldern

    private int WoodCount;      // Variable die ms z�hlt
    private int StoneCount;     // Variable die ms z�hlt

    [SerializeField]
    private IntSO WoodMsSO; // Nach wie vielen MS ein Holz erwirtschaftet wird

    [SerializeField]
    private IntSO WoodMultiplicatorSO; // Erwirtschafte H�lzer pro Zeiteinheit   

    [SerializeField]
    private StringSO WoodPlacedBuildingsSO; // Scriptable Object f�r die Position der platzierten Geb�ude

    public ToogleActivationOnSceneChange toogle;    // Leitet eine Instanz von ToogleActivationOnSceneChange ab

    [SerializeField]
    private IntSO WoodBuildingsSO; // Wie viele Geb�ude platziert wurden

    [SerializeField]
    private IntSO GoldSO; // Scriptable Object f�r den Goldwert

    [SerializeField]
    private IntSO WoodSO; // Scriptable Object f�r den Holzwert

    [SerializeField]
    private IntSO PriceWoodMultiplicatorSO; // Wie viel ein Holzst�ck wert ist

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

    [SerializeField]
    private IntSO GlobalMultiplicatorAmount;  // Scriptable Object f�r den globalen Multiplicator

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


        if (Input.GetMouseButtonDown(0) && quarryToPlace != null)     //Schaut ob die linke Maustaste gedr�ckt ist und ob ein Haus gerade platziert werden soll
        {
            Tile nearestTile = null;    // Variable die angibt welches Feld am n�chsten ist
            float shortestDistance = float.MaxValue;    // Variable, welche schaut welches Feld am n�chsten ist

            foreach (Tile tile in tiles)    // Schleife die schaut welches Feld am n�chsten ist
            {
                float distance = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)); // Schaut wo die Maus ist und welche Tile wo ist
                if (distance < shortestDistance && distance < 50)    // Schaut ob das n�chste Feld in der Schleife n�her ist als das zuvor
                {
                    shortestDistance = distance;    // Setzt die Distanz zum jetzigen Feld als k�rzeste Distanz
                    nearestTile = tile;     // Setzt die nahste Feld als nahstes Feld
                }
            }





            if (shortestDistance < 50)    // Schaut, ob das nahste Feld beim Klick nicht bef�llt ist
            {

                if (nearestTile.isOccupied == false)
                {

                    int pos = Array.IndexOf(tiles, nearestTile);    // Holt sich die Position von der am n�chsten Tile
                    StonePlacedBuildingsSO.Value += pos;   // F�gt die Position dem String hinzu

                    Instantiate(quarryToPlace, nearestTile.transform.position, Quaternion.identity);  // Setzt das Building ohne Drehung in das Feld                 
                    quarryToPlace = null;     // Entfernt das Building am Cursor 
                    nearestTile.isOccupied = true;      // Setzt das Feld auf dem das Building plaziert auf bef�llt
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
                WoodSO.Value += WoodMultiplicatorSO.Value * WoodBuildingsSO.Value * GlobalMultiplicatorAmount.Value; // Erh�t den Holzwert
                WoodCount = 0;     // Setzt den Z�hler auf 0
            }
            WoodCount++;
        }

        if (StoneBuildingsSO.Value > 0)      // Schaut ob schon etwas platziert wurde
        {

            if (StoneCount == StoneMsSO.Value)      // Wenn die Zeiteinheit vergangen ist geht es in die Methode
            {
                StoneSO.Value += StoneMultiplicatorSO.Value * StoneBuildingsSO.Value * GlobalMultiplicatorAmount.Value; // Erh�t den Holzwert
                StoneCount = 0;     // Setzt den Z�hler auf 0
            }
            StoneCount++;
        }

    }



    public void LoadQuarryPositions(Steinbruch steinbruch)    // L�dt die Buildings und platziert sie auf ihren urspr�nglichen Platz
    {

        resetSteinbruch = steinbruch;     // Legt fest, dass ein Building plaziert werden soll

        foreach (char c in StonePlacedBuildingsSO.Value)      // Schleife welche schaut welche Buildings platziert sind
        {

            int i = c - '0';    // Konvertiert char zu int
            Instantiate(resetSteinbruch, tiles[i].transform.position, Quaternion.identity);   // Platziert buildings auf ihrer vorigen Position.
            tiles[i].isOccupied = true;     // Setzt die Tiles, auf die etwas platziert wurde auf besetzt

        }
    }




    public void BuyQuarry(Steinbruch steinbruch)  // Funktion, die das platzieren eines Geb�udes m�glich macht
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

                OnFunctionExecuted?.Invoke();   // F�hrt das Ereignis in Verbindung mit dem Delegate aus 

            }
        }
    }
}
