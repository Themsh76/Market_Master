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

public class GameManager : MonoBehaviour
{

    public Text goldDisplay;    // Variable für die Anzeige des Goldwerts
    public Text holzDisplay;    // Variable für die Anzeige des Holzwerts

    private Building buildingToPlace;   // Variable für das Gebäude was plaziert werden soll
    public GameObject Grid;     // Object welches das Feld widerspiegelt
    public CustomCursor customCursor;   // Leitet eine Instanz von Customcursor ab

    public Tile[] tiles;    // Array von Feldern

    public int zähler;      // Variable die ms zählt

    [SerializeField]
    private IntSO WoodMsSO; // Nach wie vielen MS ein Holz erwirtschaftet wird

    [SerializeField]
    private IntSO WoodMultiplicatorSO; // Erwirtschafte Hölzer pro Zeiteinheit   
   
    [SerializeField]
    private StringSO PlacedBuildingsSO; // Scriptable Object für die Position der platzierten Gebäude

    public ToogleActivationOnSceneChange toogle;    // Leitet eine Instanz von ToogleActivationOnSceneChange ab

    [SerializeField]
    private IntSO BuildingsSO; // Wie viele Gebäude platziert wurden

    [SerializeField]
    private IntSO GoldSO; // Scriptable Object für den Goldwert

    [SerializeField]
    private IntSO WoodSO; // Scriptable Object für den Holzwert

    [SerializeField]
    private IntSO PriceWoodMultiplicatorSO; // Wie viel ein Holzstück wert ist


    private void Start()
    {
        toogle.OnSceneLoaded();   // Aktiviert den Toogle

    }

    
    


    private void Update()   
    {
        goldDisplay.text = GoldSO.Value.ToString(); //Updated die Anzeige jede ms 
        holzDisplay.text = WoodSO.Value.ToString(); //Updated die Anzeige jede ms 



        if (Input.GetMouseButtonDown(0) && buildingToPlace != null)     //Schaut ob die linke Maustaste gedrückt ist und ob ein Haus gerade platziert werden soll
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
                    PlacedBuildingsSO.Value += pos;   // Fügt die Position dem String hinzu

                    Instantiate(buildingToPlace, nearestTile.transform.position, Quaternion.identity);  // Setzt das Building ohne Drehung in das Feld                 
                    buildingToPlace = null;     // Entfernt das Building am Cursor 
                    nearestTile.isOccupied = true;      // Setzt das Feld auf dem das Building plaziert auf befüllt
                    Grid.SetActive(false);      // Deaktiviert das Grid
                    customCursor.gameObject.SetActive(false);   // Deaktiviert den Custom Cursor
                    Cursor.visible = true;  // Aktiviert den normalen Cursor 

                    BuildingsSO.Value++;



                }               
            }  
        }


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



    public void LoadBuildingPositions(Building building)    // Lädt die Buildings und platziert sie auf ihren ursprünglichen Platz
    {

            buildingToPlace = building;     // Legt fest, dass ein Building plaziert werden soll

            foreach (char c in PlacedBuildingsSO.Value)      // Schleife welche schaut welche Buildings platziert sind
            {

                int i = c - '0';    // Konvertiert char zu int
                Instantiate(buildingToPlace, tiles[i].transform.position, Quaternion.identity);   // Platziert buildings auf ihrer vorigen Position.
                tiles[i].isOccupied = true;     // Setzt die Tiles, auf die etwas platziert wurde auf besetzt

            }
    }




    public void BuyBuilding(Building building)  // Funktion, die das platzieren eines Gebäudes möglich macht
    {

        if (GoldSO.Value >= building.cost)      // Schaut ob man genug Gold hat
        {
            Grid.SetActive(true);       // Aktiviert das Grid
            GoldSO.Value -= building.cost;      // Zieht die Kosten vom Goldwert ab
            buildingToPlace = building;     // Legt fest, dass ein Building plaziert werden soll

            customCursor.gameObject.SetActive(true);  // Aktiviert Customcursor
            customCursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;    // Gibt den Custom Cursor ein Building was mit dem Cursor mitgeht
            Cursor.visible = false; // Deaktiviert den normalen Cursor
         
        }
    }
}
